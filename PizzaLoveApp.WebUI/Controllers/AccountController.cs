using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaLoveApp.WebUI.Identity;
using PizzaLoveApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaLoveApp.Business.Abstract;
using PizzaLoveApp.WebUI.EmailServices;
using PizzaLoveApp.WebUI.Extensions;

namespace PizzaLoveApp.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        /*
         * TODO Cart Service eklenecek
         */
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        //private IdentityUser _identityUser;
        private ICartService _cartService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _cartService = cartService;
            //_identityUser = identityUser;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userEmailExists = await _userManager.FindByEmailAsync(model.Email);

            // TODO validation error dizi olarak gönderilmeli
            if (userEmailExists != null)
            {
                ModelState.AddModelError("", "Email adresi kayıtlıdır.");
                return View(model);
            }

            var userNameExists = await _userManager.FindByNameAsync(model.UserName);

            if (userNameExists != null)
            {
                ModelState.AddModelError("", "Kullanıcı adı kullanılmaktadır.");
                return View(model);
            }

            if (model.Password.Length < 5)
            {
                ModelState.AddModelError("", "Şifreniz en az 6 karakter uzunluğunda olmalıdır.");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // TODO Added generate token
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });

                // Send Email
                string siteUri = "https://localhost:44335";
                string activateUri = $"{siteUri}{callbackUrl}";
                string body = $"Merhaba {model.FullName}; <br><br>Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank' > tıklayınız.</a>";
                MailHelper.SendMail(body, model.Email, "PizzaLove Hesap Aktifleştirme");

                // create cart object
                _cartService.InitializeCart(user.Id);

                // show message to new user for account confirmation
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "EPosta adresinize gelen link ile hesabınızı onaylayınız.",
                    Css = "warning"
                });


                // Add to create user role
                await _userManager.AddToRoleAsync(user, "user");
                
                return RedirectToAction("login", "Account");
                
            }

            ModelState.AddModelError("", "Bir hata oluştu.");
            return View(model);
        }

        public async Task<IActionResult> Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamıştır.");
                return View(model);
            }

            //Email aktivasyonu
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen hesabınızı gönderilen email ile aktifleştiriniz.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }

            ModelState.AddModelError("", "Email veya şifre hatalı.");

            return View(new LoginModel());

        }

        public async Task<IActionResult> Logout()
        {
            /*
             * TODO: çıkış yapmıyor bakılacak ve mesaj göstermiyor
             */
            await _signInManager.SignOutAsync();

            TempData.Put("message", new ResultMessage()
            {
                Title = "Oturum Kapatıldı",
                Message = "Hesabınız güvenli bir şekilde sonlandırıldı.",
                Css = "warning"
            });

            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesap Onayı",
                    Message = "Hesap onayı için bilgileriniz hatalıdır.",
                    Css = "danger"
                });
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hesap Onayı",
                        Message = "Hesabınız onaylanmıştır.",
                        Css = "success"
                    });

                    return RedirectToAction("Login");
                }
            }

            TempData.Put("message",new ResultMessage()
            {
                Title = "Hesap Onayı",
                Message = "Hesabınız Onaylanmadı",
                Css = "danger"
            });
            return View();
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                TempData.Put("message",new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Bilgileriniz Hatalı",
                    Css = "danger"
                });

                return View();
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                TempData.Put("messsage", new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Eposta adresiyle kayıtlı kullanıcı bulunamadı",
                    Css = "danger"
                });
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code
            });

            // send email
            string siteUri = "https://localhost:44335";
            string body = $"Şifrenizi yenilemek için link <a href='{siteUri}{callbackUrl}'> tıklayınız. </a>";
            MailHelper.SendMail(body, Email, "PizzaLove Şifre Sıfırlama.");

            TempData.Put("message",new ResultMessage()
            {
                Title = "Şifremi Unuttum",
                Message = "Şifrenizi yenilemeniz için mail gönderildi. Lütfen mail adresinizi kontrol ediniz.",
                Css = "warning"
            });
            return RedirectToAction("Login", "Account");

        }

        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordModel {Token = token};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                TempData.Put("message",new ResultMessage()
                {
                    Title = "Şifremi Unuttum",
                    Message = "Eposta adresiyle kayıtlı kullanıcı bulunamadı.",
                    Css = "danger"
                });

                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        public IActionResult Accessdenied()
        {
            return View();
        }

        public async Task<IActionResult> UserManager(ApplicationUser user)
        {
            // TODO login olmuş olan kullanıcı bilgileri alınacak null geliyor
            //var user = _userManager.GetUserId(User);
            var userInfo = await _userManager.GetUserAsync(User);

            return View(new UserManagerModel()
            {
                FullName = userInfo.FullName,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                UserName = userInfo.UserName,
                UserId = userInfo.Id,
                Email = userInfo.Email,
                Phone = userInfo.PhoneNumber,
                Address = userInfo.Address,
                PointPrize = userInfo.TotalPointPrize

            });
        }
    }
}

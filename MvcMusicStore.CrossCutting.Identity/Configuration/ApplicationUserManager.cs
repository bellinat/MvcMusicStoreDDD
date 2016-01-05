using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using MvcMusicStore.CrossCutting.Identity.Model;

namespace MvcMusicStore.CrossCutting.Identity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            // Configura validator para o nome do usuário
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Logica de validação e complexidade da senha
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            // Lockout
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            // Providers of Two Factor Authentication - SMS/EMAIL
            //RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "O código de segurança gerado para você é: {0}"
            //});

            //RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<ApplicationUser>
            //{
            //    Subject = "Código de Segurança",
            //    BodyFormat = "O código de segurança gerado para você é: {0}"
            //});

            // Definindo a classe de serviço de e-mail
            //EmailService = new EmailService();

            // Definindo a classe de serviço de SMS
            //SmsService = new SmsService();

            var provider = new DpapiDataProtectionProvider("Positivo");
            var dataProtector = provider.Create("EmailService");

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector);
        }
    }
}

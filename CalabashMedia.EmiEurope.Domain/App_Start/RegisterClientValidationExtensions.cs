using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(CalabashMedia.EmiEurope.Domain.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace CalabashMedia.EmiEurope.Domain.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}
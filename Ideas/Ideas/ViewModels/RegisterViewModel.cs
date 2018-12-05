using Ideas.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ideas.ViewModels
{
    public class RegisterViewModel
    {

        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }


        public ICommand ReisterCommand
        {
            get
            {
                return new Command(async() =>
                {

                    var isSuccess = await _apiServices.RegisterAsync(
                        Email, Password, ConfirmPassword);

                    if (isSuccess)
                        Message = "Registered Success!";
                    else
                    {
                        Message = "Try Again Later";
                    }

                });
            }

        }
    }
}

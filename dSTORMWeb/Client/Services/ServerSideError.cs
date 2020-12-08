using System;
using dSTORMWeb.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace dSTORMWeb.Client.Services
{
    public class ServerSideErrors : ComponentBase
    {
        [CascadingParameter] EditContext CurrentEditContext { get; set; }
        private ValidationMessageStore MessageStore;
        private string ErrorFieldName = "ServerErrorField";
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException();
            }
            MessageStore = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += (s, e) => MessageStore.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => MessageStore.Clear(e.FieldIdentifier);
        }

        public void DisplayError<T>(ResponseModel response)
        {
            var Type = typeof(T).Name;

            if (Type == typeof(MicroscopeViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Microscope with such Producer/Model/Type already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if(Type == typeof(PhysicalPropertyViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Physical Property with such Humidity/Temperature already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(ObjectiveViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Physical Property already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }

            CurrentEditContext.NotifyValidationStateChanged();

        }

    }
}
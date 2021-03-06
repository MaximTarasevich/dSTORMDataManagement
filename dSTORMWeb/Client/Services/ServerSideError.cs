﻿using System;
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
            else if (Type == typeof(LaserViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Laser with such Producer/Model/Type  already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(CameraViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Camera with such Producer/Model  already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(AOTFilterViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Filter with such Name  already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(AuthorViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Author already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(SetupViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Setup with such AotFilter/Camera/Laser/Objectie/Microscope already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(InitialVideoViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Initial Video already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(VideoFragmentViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Video fragment already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(dSTORMInfoViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Such coordinates already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(FinalImageViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Final image for this video  already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(FluorophoreViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Fluorophore with such Name already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(ResearchObjectViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Research Object with such Name already exist");
                        break;
                    case Models.Enums.ResultCode.ServerError:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Server Error :" + response.Description);
                        break;
                }
            }
            else if (Type == typeof(ExperimentViewModel).Name)
            {
                switch (response.Result)
                {
                    case Models.Enums.ResultCode.NotValidData:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Not valid data");
                        break;
                    case Models.Enums.ResultCode.AlreadyExists:
                        MessageStore.Add(CurrentEditContext.Field(ErrorFieldName), "Experiment with such elements combination already exist");
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
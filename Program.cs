using SdaTithe.Data;
using SdaTithe.Services;
using SdaTithe.Views;

ApplicationConfiguration.Initialize();
Db.Init();
Localizer.Load();
Application.Run(new LoginForm());
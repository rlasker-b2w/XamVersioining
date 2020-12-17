# Xamarin Dynamic App Versioining

GOAL: Allow a Xamarin App work against different server versions.

The purpose of this Proof of Concept is to demonstrate how we can accomplish the stated goal. In this particular concept the Xamarin application may be communicating with different servers that may be different release versions. These different server versions may have different features and code that needs to be run on the device and we will not know what version that is until after the device user has logged into the server.

## Key Components:

[VersionSelector](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp/VersionSelector.cs)
In this class we had to specifically add references to our "Version" projects otherwise the compiler does not include the apps in the application packages. This class holds key details of the currently selected application version project.

[AuthenticationService](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp/Services/AuthenticationService.cs)
This class will alert the App that a new version needs to be loaded using the MessagingCenter.

[App](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp/App.xaml.cs)
The application responds to the Login message by dynamically loading the AppShell and registering the specific version project startup services using the Microsoft DI Extensions.

[App StartUp](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp/StartUp.cs)
This class is responsible for the IServiceProvider creation and for loading the specific versions StartUp class.

[Version StartUp](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp.20.1.0/StartUp.cs)
Each version project of the app registers the MVVM components as well as the services that are subject to code versioning.

[Versioned Service](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp.20.1.1/Services/VersionedService.cs)
This class shows how a service can inherit and extend previous service versions.

[Versioned ViewModel](https://github.com/rlasker-b2w/XamVersioning/blob/main/VersionApp.20.1.1/ViewModels/HomeViewModel.cs)
This class shows how a ViewModel can inherit and extend previous version ViewModels including by overriding code for new "functionality".

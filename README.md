# Purplebricks Moble Application Developer Test

The aim of this test is to give us an idea about how you approach the development and maintenance of mobil applications. You will work from a GitHub repository which contains an existing mobile application. The test is based on very simple search properties based application that uses our live endpoints. 

The test application is using Xamarin.Forms and solution was created in Visual Studio 2019. It contains separate Android and iOS projects and you are encouraged to work on Android solution if you don't have access to MacOS. Otherwise feel free to work on both projects. Generally the changes should be done in Core and UI projects and there should be no need to modify platform specific projects other than need to set as start up project.

The code is using MVVM architectural pattern backed by MvvmCross framework. If you are not familiar with the framework you should be able to find help at [www.mvvmcross.com](https://www.mvvmcross.com/documentation/) 

Feel free to accomplish any number of the following test objectives. They vary in difficulty level and time that will be required to spend on them. Achieving all the goals will be certainly acknowledged, but it is not required.

If you run out of time or have no idea on how to solve an objective, please commit the code you have added to this point and include some notes on why you were not able to finish an objective you chose to work on.

## Test Objectives

### Objective 1 (Easy) - Allow visiting Purplebricks website from About screen

In the side menu you will find an option to land on About screen. The button at the bottom of the screen is currently not doing anything. Modify the code to allow openning "http://www.purplebricks.com" in device preffered browser.

**Tips:** 
* The page UI code is define in AboutPage.xaml and related view model in AboutViewModel.cs
* Please note that XAML file is already containing suggested binding
* Consider using (Device.OpenUri)[https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.device.openuri?view=xamarin-forms] method

### Objective 2 (Moderate) - Extend Home screen to include option to search for properties to let

Currently app searches only for the properties available to sell. Please modify the page and add some option to select between For Sale and To Let options. 

**Tips**
* The page UI code is define in HomePage.xaml and related view model in HomeViewModel.cs
* SearchService class method called FindProperties already contains boolean parameter that can be used to alternate between search results
* Suggested component is (Picker)[https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker/], but feel free to come up with your own solution

### Objective 3 (Moderate) - Extend card view of the property search result to include property address

Results of the search are displayed in the form of list view using PropertiesPage class. Currently card view of each element is just displaying an Image and property price. Extend Properties page card view to include property address information.

**Tips**
* The page UI code is defined in PropertiesPage.xaml and related view model in PropertiesViewModel.cs
* The address details can be combined from properties of SearchPropertyResult class (Address, Postcode) 

### Objective 4 (Difficult) - Allow for more property results to be fetched from endpoint

Currently only 10 properties are displayed as result of a search. Modify the relevant code to allow fetching more data as user is scrolling down. Adding a visible loading indicator while fetching new properties would be nice to have (ex.: ActivityIndicator in ListView Footer). 

**Tips**
* The page UI code is defined in PropertiesPage.xaml and related view model in PropertiesViewModel.cs
* Your start point for fetching more data should be in LoadMorePropertiesAsync method of PropertiesViewModel class
* SearchService class method called FindProperties already contains parameter (pageNumber) that should help with pagination
* Check RefreshPropertiesAsync method of PropertiesViewModel for details on how to read Metadata information 

### Objective 5 (Difficult) - Design and implement Property Details page

When taping on any of the property card views in the search results list view a new page is opened that should allow displaying more detailed information about the property. Stub model and UI classes have been already added. The service PropertyDetailsService.cs is also implemented and tied to view model. 
The details displayed on the page are of your choice, however should be limited to those available from PropertyDetailsResult class. You don't have to visualise all the properties. Consider displaying most important ones. Feel free to visit www.purplebricks.co.uk to see what sort of data is displayed when selecting property details.

**Tips**
* The page UI code is defined in PropertyDetailsPage.xaml and related view model in PropertyDetailsViewModel.cs
* For displaying images consider using [CarouselView](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/carouselview/)
* Some of the data like Floorplan or StarPoints can be displaying using separate pages (simply add new Pages and ViewModels in respective projects)

### Objective 6 (Moderate) - Write a short review of the existing sample codebase.

Let us know what you think is good or bad about it. Feel free to fix any problems and commit these changes to the solution.

#### Deliverables

Your submission should be delivered in as a Visual Studio solution compatible with Visual Studio 2019. The solution should compile. 

We would prefer that the solution is delivered via GitHub. If you are not able to fork this original repository publically then please fork to a private repository and then provide us with the zip file from the download option in GitHub.

Good luck!

## FAQs

* Should I show my commit history?
    * Showing your commit history is recommended so that we can see your approach.

* How long should I spend working on the assignment?
    * You can take as long as you need to complete the assignment. But do remember that this is throwaway code and the aim is to demonstrate your approach rather than build a complete system.

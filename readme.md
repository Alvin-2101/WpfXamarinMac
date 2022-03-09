
# Application
This is a desktop (C#/Xamarin/WPF) application to show next trains for an Irish Rail Company for my facourite stations

## Note:
    - Please spend maximum around 1-3 hours working on this
    - We don't expect candidates to finish everything in that timeframe, just make as much progress as possible. 
    - Quality and working code is more important than amount tasks done!
    - Test can be completed on Windows (InterviewRailWin.sln) or on Mac (InterviewRailMac.sln)

## All code should be:
    - Clean and readable code.
    - Follow Good Coding practices (SOLID, DI, ..)

## Goals:
    - Fix any code compilation issues
    - Mac only: Make the TableView of the Station list resize with the window
    - We want the user to have the ability to save a station as a favourite
        - Make a new column on the TableView/DataGrid with a checkbox to mark station as favourite
        - Save the favourites to settings, so they are avaliable after restarting the app
    - Modify the MainViewModel to update the station list in every 4 minutes
    - Create a unit test for the RailService
        - eg.: test if it's calling the correct endpoint
    - Have a separate window for the list of favourites
        - Will need a new service call
        - Should display the Name of the station and the next trains
        - Should show Train's Destination, and Extimated arrival time
            - HINT: on Mac use NSOutlineView to display trains under stations
            - HINT: on Windows use RowDetails
        - When marking a sation favourite, this list must auto update
            - HINT: on Mac the DynamicReactiveTableDataSource is there to help updating the list dynamically
        - Also update the favourite list every minute to show the updated estimated arrival time
            - HINT: use the Reactive Extensions to schedule a refresh on the VM
        

## Tools :
    - Latest Visual Studio for Mac : https://visualstudio.microsoft.com/vs/mac/
    - Latest Visual Studio for Windows : https://visualstudio.microsoft.com/downloads/
    - or Rider

## Some References that might help:
    - API to get the trains for stations http://api.irishrail.ie/realtime/
    - https://www.reactiveui.net/docs/getting-started/
    - https://www.reactiveui.net/docs/guidelines/framework/ui-thread-and-schedulers
    - https://www.reactiveui.net/docs/guidelines/framework/asynchronous-commands
    - https://dynamic-data.org/
    - https://flurl.dev/docs/fluent-http/
    - https://flurl.dev/docs/testable-http/
    - https://nunit.org/

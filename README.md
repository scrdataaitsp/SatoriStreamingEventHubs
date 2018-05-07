<h1>Satori Streaming Event Hubs</h1>

This project ingests data from the Satori Streaming API that has live data feeds from around the world. The implementation included here ingests a stream of data that gets public bus transportation data/coordinates from many carriers. This is a good set of data to stream into Spark Structured Streaming or Stream Analytics as a pass through to Power BI
<br>
<br>
You can see the live Satori feeds here: https://www.satori.com/livedata/channels
<br>
<br>
To Do:
<br>
* When opening the C# project, you are going to have to rebuild to retreive all of the NuGet packages that are required
* Rename App.config.example to App.Config
* Go to the Satori feed you are using (for example the transportation feed is here: https://www.satori.com/livedata/channels/transportation) and copy the Appkey. It says it expires in 7 days but it usually lasts several weeks. There is an option to get a permenant key there as well.
* Go to https://portal.azure.com and create an EventHub that you will be using
* In the App.config scroll to the AppSettings section and enter the Satori key and event hub info there
<br>
<br>
Your app should now be good to go. You can use it in debug mode or deploy it.
# XF4SD_MasterDetail
Modified Master Detail Surface Duo sample Xamarin Forms app provided by Microsoft to add Toolbar Items

For an introduction to Surface Duo SDK Preview refer to the blog post [Xamarin Goes Dual Screen](https://devblogs.microsoft.com/xamarin/xamarin-goes-dual-screen/) by David Ortinau. You can also watch the YouTube video [Xamarin: Exploring the SDK for Surface Duo](https://www.youtube.com/watch?time_continue=3850&v=-Ey68OIKNWY&feature=emb_logo) which is part of that blog.

You can also go through the blog post [Surface Duo at Microsoft Build (2020)](https://devblogs.microsoft.com/surface-duo/surface-duo-at-microsoft-build/) by Craig Dunn.

It should be noted that this SDK is under active development and hence they are bound to be issues. This code was picked from the [Surface Duo SDK Xamarin Samples](https://github.com/microsoft/surface-duo-sdk-xamarin-samples) on GitHub. Master Detail is of particular interest to me as my apps are modelled on this traditional template (Note that this is different from the MasterDetail app template provided in VS).

The main problem with **TwoPaneView** is that **ContentPage**s can't be set as its children and traditionally **ContentView**s are used for the *Panes*. And a **ContentView** doesn't have definition for **ToolBarItems** which is extensively used in apps. Yes the existing **ToolbarItems** can be moved to the ***MasterPage*** but that only moves them for the *Pane1*. What about **ToolbarItems** that are in the Page for *Pane2*. Also the **Toolbar** of the ***MasterPage*** spans both the panes in dual screen mode.

So, I modified the existing ***MasterDetail*** sample to add a *Toolbar* to the ***Details.xaml*** that is visible only when the app is in *Dual Screen Mode*. When it is in *Single Screen Mode*, the app is displaying ***DetailsPage***. Since this is a **ContentPage**, traditional **ToolbarItems** were added to it. And the event handlers for these *Toolbar Items* in both the pages will call the methods situated in the ***MasterDetail.xaml.cs*** which is the *Master Page*.

The API for the **TwoPane** view is excellent that the app runs beautifully on a normal Android phone emulator, iOS Simulator and UWP Local Machine.

## One Issue is:
Whether the *Toolbar* **StackLayout** in the ***Details.xaml*** is displayed or not is dependent on the value of **IsSpanned** in ***DetailsPage.xaml.cs***. The relevant code is given below:

```
bool IsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;
```

But it is found that this setting is ***not stable***. *Sometimes* when in *Dual Screen Mode*, when an item in the left pane is selected the *Details* goes into *Single Screen Mode* and the *Toolbar* **StackLayout** disappears. This doesn't happen all times.

## Next Steps:
Since this SDK is in preview and under active development, I don't know if there is a plan to include individual **ToolbarItems** to the two *Panes*. Till then I suppose the method used in the project is the solution.

Of course, anyone seeing this can suggest if they have a better method if I am missing something.

Also I am working on adopting this SDK to **TabbedPage** with multiple tabs that contain serveral *MasterDetail* pages and also the different pages are fired from the buttons in the **ListView** items. Let me see how it goes...

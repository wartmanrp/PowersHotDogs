﻿using Android.App;
using Android.Content;
//using Android.Gms.Maps;
//using Android.Gms.Maps.Model;
using Android.Media;
using Android.OS;
using Android.Widget;
using System;

namespace PowersHotDogs
{
   [Activity(Label = "Visit Powers' store")]
   public class PowersMapActivity : Activity
   {
      private Button externalMapButton;
      //private FrameLayout mapFrameLayout;
      //private MapFragment mapFragment;
      //private GoogleMap googleMap;
      //private LatLng powersLocation;

      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);

         //powersLocation = new Rating(35.227543, -80.843884);

         SetContentView(Resource.Layout.PowersMapView);

         FindViews();

         HandleEvents();

         //CreateMapFragment();

         //UpdateMapView();
      }
      private void FindViews()
      {
         externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
         //mapFrameLayout = FindViewById<FrameLayout>(Resource.Id.mapFrameLayout);
      }

      private void HandleEvents()
      {
         externalMapButton.Click += ExternalMapButton_Click;
      }

      private void ExternalMapButton_Click(object sender, EventArgs e)
      {
         Android.Net.Uri powersLocationUri = 
            Android.Net.Uri.Parse("geo:35.227543,-80.843884");
         Intent mapIntent = new Intent(Intent.ActionView, powersLocationUri);
         StartActivity(mapIntent);
      }


      //private void UpdateMapView()
      //{
      //   var mapReadyCallback = new LocalMapReady();

      //   mapReadyCallback.MapReady += (sender, args) =>
      //   {
      //      googleMap = (sender as LocalMapReady).Map;

      //      if (googleMap != null)
      //      {
      //         MarkerOptions markerOptions = new MarkerOptions();
      //         markerOptions.SetPosition(rayLocation);
      //         markerOptions.SetTitle("Powers' Hot Dogs");
      //         googleMap.AddMarker(markerOptions);

      //         CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(rayLocation, 15);
      //         googleMap.MoveCamera(cameraUpdate);
      //      }
      //   };

      //   mapFragment.GetMapAsync(mapReadyCallback);
      //}

      //private void CreateMapFragment()
      //{
      //   mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

      //   if (mapFragment == null)
      //   {
      //      var googleMapOptions = new GoogleMapOptions()
      //          .InvokeMapType(GoogleMap.MapTypeSatellite)
      //          .InvokeZoomControlsEnabled(true)
      //          .InvokeCompassEnabled(true);

      //      FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
      //      mapFragment = MapFragment.NewInstance(googleMapOptions);
      //      fragmentTransaction.Add(Resource.Id.mapFrameLayout, mapFragment, "map");
      //      fragmentTransaction.Commit();
      //   }
      //}



      //private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
      //{
      //   public GoogleMap Map { get; private set; }

      //   public event EventHandler MapReady;

      //   public void OnMapReady(GoogleMap googleMap)
      //   {
      //      Map = googleMap;
      //      var handler = MapReady;
      //      if (handler != null)
      //         handler(this, EventArgs.Empty);
      //   }
      //}
   }
}
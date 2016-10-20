using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core;

namespace PowersHotDogs.Fragments
{
   public class BaseFragment : Fragment
   {
      protected ListView listView;
      protected HotDogDataService hotDogDataService;
      protected List<HotDog> hotDogs;

      public BaseFragment()
      {
         hotDogDataService = new HotDogDataService();
      }

      protected void HandleEvents()
      {
         listView.ItemClick += ListView_ItemClick;
      }

      private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
      {
         var hotDog = hotDogs[e.Position];

         var intent = new Intent();
         intent.SetClass(this.Activity, typeof(HotDogDetailActivity));
         intent.PutExtra("selectedHotDogId", hotDog.HotDogId);

         StartActivityForResult(intent, 100);        
      }

      protected void FindViews()
      {
         listView = this.View.FindViewById<ListView>(Resource.Id.hotDogListView);
      }
   }
}
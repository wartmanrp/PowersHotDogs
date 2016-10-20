using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Provider;
using Java.IO;
using Android.Graphics;
using PowersHotDogs.Utility;

namespace PowersHotDogs
{

   [Activity(Label = "Take a picture with Powers", Icon = "@drawable/smallicon")]
   public class TakePictureActivity : Activity
   {
      private ImageView powersPictureImageView;
      private Button takePictureButton;
      private File imageDirectory;
      private File imageFile;
      private Bitmap imageBitmap;

      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);

         SetContentView(Resource.Layout.TakePictureView);

         FindViews();

         HandleEvents();

         //create directory to store image
         imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
             Android.OS.Environment.DirectoryPictures), "PowersHotDogs");

         if (!imageDirectory.Exists())
         {
            imageDirectory.Mkdirs();
         }
      }

      private void FindViews()
      {
         powersPictureImageView = FindViewById<ImageView>(Resource.Id.powersPictureImageView);
         takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
      }

      private void HandleEvents()
      {
         takePictureButton.Click += TakePictureButton_Click;
      }

      private void TakePictureButton_Click(object sender, EventArgs e)
      {
         Intent intent = new Intent(MediaStore.ActionImageCapture);

         imageFile = new File(imageDirectory, String.Format("PhotoWithPowers_{0}.jpg", Guid.NewGuid()));
         intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

         StartActivityForResult(intent, 0);
      }

      protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
      {
         base.OnActivityResult(requestCode, resultCode, data);

         int height = Resources.DisplayMetrics.HeightPixels;
         int width = powersPictureImageView.Height;
         imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

         if (imageBitmap != null)
         {
            powersPictureImageView.SetImageBitmap(imageBitmap);
            imageBitmap = null;
         }

         //required to avoid memory leaks!
         GC.Collect();
      }


   }
}
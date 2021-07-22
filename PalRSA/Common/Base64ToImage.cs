﻿using System;
using System.IO;
using System.Drawing;

namespace Recapture.Common
{
    public class Base64ToImage
    {
        public Image Base64ToImages(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}
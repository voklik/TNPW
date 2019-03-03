using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TNPW.utility
{

    public class ImageHelper
{


    public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
    {
        var ratiox = (double) maxWidth / image.Width;
        var ratioy = (double)maxHeight / image.Height;
        var ratio = Math.Min(ratiox, ratioy);

        var newWidth = (int) (image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newimage = new Bitmap(newWidth,newHeight);

        Graphics.FromImage(newimage).DrawImage(image,0,0,newWidth,newHeight);
        return newimage;


    }
}
}
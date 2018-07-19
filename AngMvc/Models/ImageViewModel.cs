using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngMvc.Models
{
    public class ImageViewModel
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string Image { get; set; }

        public ImageViewModel(MyImage In)
        {
            ImageId = In.ImageId;
            ImageName = In.ImageName;
            Image = Convert.ToBase64String(In.Image);
        }
    }
}
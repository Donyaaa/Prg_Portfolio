﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class VM_PageBlog
    {
        //Footeeer------------------------------------------------------------
        public IEnumerable<Vm_PictureProduct> PortofioProductVM { get; set; }
        //Blog-------------------------------------------------------------------
        public IEnumerable<Vm_PictureBlog> PictureBlogVMNew { get; set; }
        //LeftSide-------------------------------------------------------------
        public IEnumerable<Vm_PictureProduct> PortofioProductVM2 { get; set; }
        public IEnumerable<Vm_Tag> TagVM { get; set; }
        public IEnumerable<Vm_Sentencess> SentensessVM { get; set; }
        public IEnumerable<Vm_CommentBlog> CommentBlogVM { get; set; }
    }
}
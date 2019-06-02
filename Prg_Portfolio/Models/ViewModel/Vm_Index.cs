using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prg_Portfolio.Models.DomainModel;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_Index
    {
        
        /// <summary>
        /// View Model For Picture Repository
        /// </summary>
        public IEnumerable<Vm_Picture> PictureVM { get; set; }

        /// <summary>
        /// View Model For Subscribe Repository
        /// </summary>
        public Vm_Subscribe SubscribeVM { get; set; }

        /// <summary>
        /// View Model For ContactUs Repository
        /// </summary>
        public Vm_ContactUs CountactUsVM { get; set; }

        /// <summary>
        /// View Model For PictureUser Repository
        /// </summary>
        public IEnumerable<Vm_PictureUser> PictureTeamVm { get; set; }

        /// <summary>
        /// View Model For PictureProduct Repository
        /// </summary>
        public IEnumerable<Vm_PictureProduct> PictureProductVMNew { get; set; }

        /// <summary>
        /// View Model For PicturePrudect Repository For Footer
        /// </summary>
        public IEnumerable<Vm_PictureProduct> PortofioProductVM { get; set; }

        /// <summary>
        /// View Model For PictureBlog Repository
        /// </summary>
        public IEnumerable<Vm_PictureBlog> PictureBlogVMNew { get; set; }

        /// <summary>
        /// View Model For CommentProduct And Picture Repository
        /// </summary>
        public IEnumerable<Vm_ComProList> VmPicProList { get; set; }
    }
}
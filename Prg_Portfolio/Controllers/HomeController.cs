using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prg_Portfolio.Models.DomainModel;
using Prg_Portfolio.Models.Repository;

using Prg_Portfolio.Models.ViewModel;
using System.Threading;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Globalization;
using Prg_Portfolio.Models.ExtentionMethods;

namespace Prg_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        //Create Obj
        UnitOfWork db = new UnitOfWork();
        Vm_Index indexVm = new Vm_Index();
        VM_PageBlog PageBlog = new VM_PageBlog();
        Thread tr1;
        Thread tr2;

        /// <summary>
        /// The Main Page
        /// </summary>
        /// <returns>Page Values</returns>
        public ActionResult Index()
        {
            //Gallery----------------------------------------------------------
            var q = db.Rep_Product_Picture.Get().Select(a => new Vm_Picture
            {
                Name = a.Tbl_Picture.Name,
                PicturePath = a.Tbl_Picture.PicturePath,
                ProductName = a.Tbl_Products.NameProduct,
                CategoryID = a.Tbl_Products.Tbl_Category.Id
            }).ToList();
            q.Reverse();
            indexVm.PictureVM = q.Take(8);

            //User---------------------------------------------------------------
            var t = db.Rep_CommentProduct.Get().Select(mk => new Vm_ComProList
            {
                UserName = new Vm_User { FirstName = mk.Tbl_User.FirstName, LastName = mk.Tbl_User.LastName, Description = mk.Tbl_User.Description },
                ComentPro = new Vm_CommentProduct { Text = mk.Text },
                PictureVMNew = db.Rep_User_Picture.Get(u => u.User_Id == mk.User_Id).Select(a => new Vm_Picture { Name = a.Tbl_Picture.Name }).FirstOrDefault(),
                UserTypVMNew = db.Rep_User.Get(u => u.UserType_Id==mk.Tbl_User.UserType_Id).Select(r=>new Vm_UserType { Type = r.Tbl_UserType.Type}).FirstOrDefault()

            }).ToList();

            indexVm.VmPicProList = t.Take(3);

            //Product------------------------------------------------------------
            var y = db.Rep_Product_Picture.Get().Select(e => new Vm_PictureProduct
            {
                ProductVMNew = new Vm_Product { NameProduct = e.Tbl_Products.NameProduct },
                PicturVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                PriceVMNew = db.Rep_PriceProduct.Get(yt => yt.Products_Id == e.Product_Id).Select(a => new Vm_Price { Price = a.Tbl_Price.Price }).LastOrDefault()

            }).ToList();
            y.Reverse();
            indexVm.PictureProductVMNew = y.Take(4);

            //Blog---------------------------------------------------------------
            var p = db.Rep_Blog_Picture.Get().Select(e => new Vm_PictureBlog
            {
                BlogVMNew = new Vm_Blog { Title = e.Tbl_Blog.Title, Description = e.Tbl_Blog.Description, Text = e.Tbl_Blog.Text, Date = ((DateTime)e.Tbl_Blog.Date).DateTimeToShamsi() },
                PictureVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                UserName = db.Rep_Blog.Get(uj => uj.User_Id == e.Tbl_Blog.User_Id).Select(a => new Vm_User { FirstName = a.Tbl_User.FirstName, LastName= a.Tbl_User.LastName }).LastOrDefault()
            }).ToList();
            indexVm.PictureBlogVMNew = p.Take(3);

            //Newsletters--------------------------------------------------------
            //tr2 = new Thread(() => Send());
            //tr2.Start();

            //Footer------------------------------------------------------------
            var m = db.Rep_SellFactorDetail.Get().Select(a => a).GroupBy(a => a.Products_Id).ToList().OrderByDescending(a => a.Count()).Take(2);
            List<Vm_PictureProduct> Li = new List<Vm_PictureProduct>();

            foreach (var item in m)
            {
                var y1 = db.Rep_Product_Picture.Get(a => a.Product_Id == item.Key).Select(e => new Vm_PictureProduct
                {
                    ProductVMNew = new Vm_Product { NameProduct = e.Tbl_Products.NameProduct },
                    PicturVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                    PriceVMNew = db.Rep_PriceProduct.Get(a => a.Products_Id == e.Product_Id).Select(a => new Vm_Price { Price = a.Tbl_Price.Price }).LastOrDefault()
                }).ToList().FirstOrDefault();

                Li.Add(y1);
            }
            indexVm.PortofioProductVM = Li;

            return View(indexVm);
        }

        /// <summary>
        /// Contact Us
        /// </summary>
        /// <param name="result">Object That We Need</param>
        /// <returns>Value That Sended From The Web Page</returns>
        [HttpPost]
        public JsonResult ContactUs(Vm_Index result)
        {
            if (result.CountactUsVM.Name == null
                || result.CountactUsVM.Subject == null
                || result.CountactUsVM.Massage == null
                || result.CountactUsVM.Email == null)
            {
                return Json("Failed");
            }
            else
            {
                try
                {
                    Tbl_ContactUS tbl = new Tbl_ContactUS();
                    tbl.Name = result.CountactUsVM.Name.Trim();
                    tbl.Email = result.CountactUsVM.Email.Trim();
                    tbl.IsActive = true;
                    tbl.Subject = result.CountactUsVM.Subject.Trim();
                    tbl.Massage = result.CountactUsVM.Massage.Trim();
                    tbl.CreationDateTime = DateTime.Now;
                    db.Rep_ContactUS.Insert(tbl);
                    db.Rep_ContactUS.Save();

                    return Json("Success");
                }
                catch (Exception ex)
                {
                    return Json("Exeption: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">Object That We Need</param>
        /// <returns>Value That Sended From The Web Page</returns>
        [HttpPost]
        public JsonResult Subscribe(Vm_Index result)
        {
            if (result.SubscribeVM.Email == null)
            {
                return Json("Failed");
            }
            else
            {
                var q = db.Rep_Subscribe.Get(x => x.Email == result.SubscribeVM.Email).Select(x => x.Id).Count();
                if (q != 0)
                {
                    return Json("Exist");
                }
                else
                {
                    try
                    {
                        Tbl_Subscribe tbl = new Tbl_Subscribe();
                        tbl.Email = result.SubscribeVM.Email.Trim();
                        tbl.CreationDateTime = DateTime.Now;
                        tbl.IsActive = true;
                        db.Rep_Subscribe.Insert(tbl);
                        db.Rep_Subscribe.Save();

                        return Json("Success");
                    }
                    catch (Exception ex)
                    {
                        return Json("Exeption : " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Descriptuion About The Owner Of The Site
        /// </summary>
        /// <returns>Value That Sended From The Web Page</returns>
        public ActionResult AboutUs()
        {
            //User---------------------------------------------------------------
            var t = db.Rep_CommentProduct.Get().Select(mk => new Vm_ComProList
            {
                UserName = new Vm_User { FirstName = mk.Tbl_User.FirstName, LastName = mk.Tbl_User.LastName, Description = mk.Tbl_User.Description },
                ComentPro = new Vm_CommentProduct { Text = mk.Text },
                PictureVMNew = db.Rep_User_Picture.Get(u => u.User_Id == mk.User_Id).Select(a => new Vm_Picture { Name = a.Tbl_Picture.Name }).FirstOrDefault(),
                UserTypVMNew = db.Rep_User.Get(u => u.UserType_Id == mk.Tbl_User.UserType_Id).Select(r => new Vm_UserType { Type = r.Tbl_UserType.Type }).FirstOrDefault()

            }).ToList();

            indexVm.VmPicProList = t.Take(3);
            //Team----------------------------------------------------------------

            var ty = db.Rep_User_Picture.Get().Select(e => new Vm_PictureUser
            {
                PictureVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                UserVMNew = new Vm_User { FirstName = e.Tbl_User.FirstName, LastName = e.Tbl_User.LastName, Description = e.Tbl_User.Description },
                UserTypVMNew = new Vm_UserType { Type = e.Tbl_User.Tbl_UserType.Type },
                ListLink = db.Rep_Link.Get(d => d.User_Id == e.User_Id).Select(b => new Vm_Link { LinkPath = b.LinkPath, linkType_Id = b.linkType_Id })

            }).ToList();
            ty.Reverse();
            indexVm.PictureTeamVm = ty.Take(4);

            //Footer------------------------------------------------------------
            var m = db.Rep_SellFactorDetail.Get().Select(a => a).GroupBy(a => a.Products_Id).ToList().OrderByDescending(a => a.Count()).Take(2);
            List<Vm_PictureProduct> Li = new List<Vm_PictureProduct>();

            foreach (var item in m)
            {
                var y1 = db.Rep_Product_Picture.Get(a => a.Product_Id == item.Key).Select(e => new Vm_PictureProduct
                {
                    ProductVMNew = new Vm_Product { NameProduct = e.Tbl_Products.NameProduct },
                    PicturVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                    PriceVMNew = db.Rep_PriceProduct.Get(a => a.Products_Id == e.Product_Id).Select(a => new Vm_Price { Price = a.Tbl_Price.Price }).LastOrDefault()
                }).ToList().FirstOrDefault();

                Li.Add(y1);
            }
            indexVm.PortofioProductVM = Li;
            //--------------------------------------------------------------------

            return View(indexVm);
        }

        /// <summary>
        /// For Sending The Email That Users Where Subscribe
        /// </summary>
        public ActionResult Blog()
        {
            //Blog---------------------------------------------------------------
            var p2 = db.Rep_Blog_Picture.Get().Select(e => new Vm_PictureBlog
            {
                BlogVMNew = new Vm_Blog { Title = e.Tbl_Blog.Title, Description = e.Tbl_Blog.Description, Text = e.Tbl_Blog.Text, Date = ((DateTime)e.Tbl_Blog.Date).DateTimeToShamsi() },
                PictureVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                UserName = db.Rep_Blog.Get(uj => uj.User_Id == e.Tbl_Blog.User_Id).Select(a => new Vm_User { FirstName = a.Tbl_User.FirstName, LastName = a.Tbl_User.LastName }).LastOrDefault()
            }).ToList();
            PageBlog.PictureBlogVMNew = p2.Take(2);

            //LeftSide Best Seller------------------------------------------------------------
            var m2 = db.Rep_SellFactorDetail.Get().Select(a => a).GroupBy(a => a.Products_Id).ToList().OrderByDescending(a => a.Count()).Take(3);
            List<Vm_PictureProduct> Li2 = new List<Vm_PictureProduct>();

            foreach (var item in m2)
            {
                var y1 = db.Rep_Product_Picture.Get(a => a.Product_Id == item.Key).Select(e => new Vm_PictureProduct
                {
                    ProductVMNew = new Vm_Product { NameProduct = e.Tbl_Products.NameProduct },
                    PicturVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                    PriceVMNew = db.Rep_PriceProduct.Get(a => a.Products_Id == e.Product_Id).Select(a => new Vm_Price { Price = a.Tbl_Price.Price }).LastOrDefault()
                }).ToList().FirstOrDefault();

                Li2.Add(y1);
            }
            PageBlog.PortofioProductVM2 = Li2;

            //Footer------------------------------------------------------------
            var m = db.Rep_SellFactorDetail.Get().Select(a => a).GroupBy(a => a.Products_Id).ToList().OrderByDescending(a => a.Count()).Take(2);
            List<Vm_PictureProduct> Li = new List<Vm_PictureProduct>();

            foreach (var item in m)
            {
                var y1 = db.Rep_Product_Picture.Get(a => a.Product_Id == item.Key).Select(e => new Vm_PictureProduct
                {
                    ProductVMNew = new Vm_Product { NameProduct = e.Tbl_Products.NameProduct },
                    PicturVMNew = new Vm_Picture { Name = e.Tbl_Picture.Name, PicturePath = e.Tbl_Picture.PicturePath },
                    PriceVMNew = db.Rep_PriceProduct.Get(a => a.Products_Id == e.Product_Id).Select(a => new Vm_Price { Price = a.Tbl_Price.Price }).LastOrDefault()
                }).ToList().FirstOrDefault();

                Li.Add(y1);
            }
            PageBlog.PortofioProductVM = Li;
            //-------------------------------------------------------------------
            return View(PageBlog);
        }

        /// <summary>
        /// Send The Email For SubScribers
        /// </summary>
        public void Send()
        {
            string ty = "<html><head></head><body>";
            while (true)
            {
                var ry = db.Rep_Blog.Get().Select(c => c.Title).ToList();
                ry.Reverse();
                foreach (var item in ry.Take(3))
                {
                    ty += "<h1 style=\"color:red;\">" + item.ToString() + "</h1><br/>";
                }

                var q6 = db.Rep_Subscribe.Get().Select(x => x.Email).ToList();
                foreach (var item in q6)
                {
                    string t2 = @"This Is Subject";
                    ty += "</body></html>";
                    tr1 = new Thread(() => SendEmail(item.ToString(), t2, ty));
                    tr1.Start();
                }
                Thread.Sleep(604800000);
                ty = "";
            }
        }

        /// <summary>
        /// The Index Of Email Where Will Send To User Who had Subscribe
        /// </summary>
        /// <param name="toEmail">The Email Of user</param>
        /// <param name="subject">Subject Of The Email</param>
        /// <param name="emailbody">Description Of The Email</param>
        public void SendEmail(string toEmail, string subject, string emailbody)
        {
            string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
            string senderPassword =
            System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);
            MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailbody);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            client.Send(mailMessage);
        }
    }
}


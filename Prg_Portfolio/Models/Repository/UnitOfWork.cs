using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prg_Portfolio.Models.DomainModel;

namespace Prg_Portfolio.Models.Repository
{
    public class UnitOfWork : IDisposable

    {
        DB_PortfolioEntities db = new DB_PortfolioEntities();

        private Rep<Tbl_Products> _Rep_Products;
        public Rep<Tbl_Products> Rep_Products
        {
            get
            {
                if (_Rep_Products == null)
                {
                    _Rep_Products = new Rep<Tbl_Products>(db);

                }
                return _Rep_Products;
            }
        }

        private Rep<Tbl_Product_Picture> _Rep_Product_Picture;
        public Rep<Tbl_Product_Picture> Rep_Product_Picture
        {
            get
            {
                if (_Rep_Product_Picture == null)
                {
                    _Rep_Product_Picture = new Rep<Tbl_Product_Picture>(db);

                }
                return _Rep_Product_Picture;
            }
        }

        private Rep<Tbl_UserPicture> _Rep_User_Picture;
        public Rep<Tbl_UserPicture> Rep_User_Picture
        {
            get
            {
                if (_Rep_User_Picture == null)
                {
                    _Rep_User_Picture = new Rep<Tbl_UserPicture>(db);

                }
                return _Rep_User_Picture;
            }
        }

        private Rep<Tbl_Price> _Rep_Price;
        public Rep<Tbl_Price> Rep_Price
        {
            get
            {
                if (_Rep_Price == null)
                {
                    _Rep_Price = new Rep<Tbl_Price>(db);
                }
                return _Rep_Price;

            }
        }

        private Rep<Tbl_User> _Rep_User;
        public Rep<Tbl_User> Rep_User
        {
            get
            {
                if (_Rep_User == null)
                {
                    _Rep_User = new Rep<Tbl_User>(db);
                }
                return _Rep_User;
            }
        }

        private Rep<Tbl_Blog> _Rep_Blog;
        public Rep<Tbl_Blog> Rep_Blog
        {
            get
            {
                if (_Rep_Blog == null)
                {
                    _Rep_Blog = new Rep<Tbl_Blog>(db);
                }
                return _Rep_Blog;
            }
        }

        private Rep<Tbl_Subscribe> _Rep_Subscribe;
        public Rep<Tbl_Subscribe> Rep_Subscribe
        {
            get
            {
                if (_Rep_Subscribe == null)
                {
                    _Rep_Subscribe = new Rep<Tbl_Subscribe>(db);
                }
                return _Rep_Subscribe;
            }
        }

        private Rep<Tbl_ContactUS> _Rep_ContactUS;
        public Rep<Tbl_ContactUS> Rep_ContactUS
        {
            get
            {
                if (_Rep_ContactUS == null)
                {
                    _Rep_ContactUS = new Rep<Tbl_ContactUS>(db);
                }
                return _Rep_ContactUS;
            }
        }

        private Rep<Tbl_Blog_Picture> _Rep_Blog_Picture;
        public Rep<Tbl_Blog_Picture> Rep_Blog_Picture
        {
            get
            {
                if (_Rep_Blog_Picture == null)
                {
                    _Rep_Blog_Picture = new Rep<Tbl_Blog_Picture>(db);
                }
                return _Rep_Blog_Picture;
            }
        }

        private Rep<Tbl_Picture> _Rep_Picture;
        public Rep<Tbl_Picture> Rep_Picture
        {
            get
            {
                if (_Rep_Picture == null)
                {
                    _Rep_Picture = new Rep<Tbl_Picture>(db);
                }
                return _Rep_Picture;
            }
        }

        private Rep<Tbl_SellFactorDetail> _Rep_SellFactorDetail;
        public Rep<Tbl_SellFactorDetail> Rep_SellFactorDetail
        {
            get
            {
                if (_Rep_SellFactorDetail == null)
                {
                    _Rep_SellFactorDetail = new Rep<Tbl_SellFactorDetail>(db);
                }
                return _Rep_SellFactorDetail;
            }
        }

        private Rep<Tbl_Price_Products> _Rep_PriceProduct;
        public Rep<Tbl_Price_Products> Rep_PriceProduct
        {
            get
            {
                if (_Rep_PriceProduct == null)
                {
                    _Rep_PriceProduct = new Rep<Tbl_Price_Products>(db);
                }
                return _Rep_PriceProduct;
            }
        }

        private Rep<Tbl_Link> _Rep_Link;
        public Rep<Tbl_Link> Rep_Link
        {
            get
            {
                if (_Rep_Link == null)
                {
                    _Rep_Link = new Rep<Tbl_Link>(db);
                }
                return _Rep_Link;
            }
        }

        private Rep<Tbl_CommentProduct> _Rep_CommentProduct;
        public Rep<Tbl_CommentProduct> Rep_CommentProduct
        {
            get
            {
                if (_Rep_CommentProduct == null)
                {
                    _Rep_CommentProduct = new Rep<Tbl_CommentProduct>(db);
                }
                return _Rep_CommentProduct;
            }
        }

        private Rep<Tbl_Tag> _Rep_Tag;
        public Rep<Tbl_Tag> Rep_Tag
        {
            get
            {
                if (_Rep_Tag == null)
                {
                    _Rep_Tag = new Rep<Tbl_Tag>(db);
                }
                return _Rep_Tag;
            }
        }

        private Rep<Tbl_Sentensess> _Rep_Sentensess;
        public Rep<Tbl_Sentensess> Rep_Sentensess
        {
            get
            {
                if (_Rep_Sentensess == null)
                {
                    _Rep_Sentensess = new Rep<Tbl_Sentensess>(db);
                }
                return _Rep_Sentensess;
            }
        }

        private Rep<Tbl_CommentBlog> _Rep_CommentBlog;
        public Rep<Tbl_CommentBlog> Rep_CommentBlog
        {
            get
            {
                if (_Rep_CommentBlog == null)
                {
                    _Rep_CommentBlog = new Rep<Tbl_CommentBlog>(db);
                }
                return _Rep_CommentBlog;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllComics : System.Web.UI.Page
{

    static Random oRandomComic = new Random();
    static int iRandomComic = 0;

    const int iFirstComic = 1;
    static int iLatestComic = 2286;
    static int iCurrentComic = iLatestComic;


    static ComicsDBDataContext db = new ComicsDBDataContext();



    //Grab the latest comic first
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {

            iRandomComic = oRandomComic.Next(0, iLatestComic + 1);
            iCurrentComic = iRandomComic;

            var doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
            while (doesComicExist == false)
            {
                iRandomComic = oRandomComic.Next(0, iLatestComic + 1);
                iCurrentComic = iRandomComic;
                doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
            }

            ComicData comicImage = db.ComicDatas.Single(o => o.TotalNumber == (iCurrentComic));
            ImageButton1.ImageUrl = comicImage.FilePath;
            


        }




    }





    protected void LinkButtonFirst_Click(object sender, EventArgs e)
    {
        iCurrentComic = iFirstComic;

        var doesComicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber.Equals(iCurrentComic));
        
        while (doesComicActuallyExist == false)
        {
            iCurrentComic++;
            doesComicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicImage.FilePath;
    }






    //Decrement to the next lowest comic filename
    //    check to see decrement isn't below the very first comic
    protected void LinkButtonPrevious_Click(object sender, EventArgs e)
    {

        if (iCurrentComic > 1)
        {
            iCurrentComic--;
        }

        var doescomicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        while (doescomicActuallyExist == false)
        {
            iCurrentComic--;
            if (iCurrentComic < 0)
            {
                iCurrentComic = iFirstComic;
            }

            doescomicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicImage.FilePath;

    }






    protected void LinkButtonRandom_Click(object sender, EventArgs e)
    {
        iRandomComic = oRandomComic.Next(0, iLatestComic + 1);
        iCurrentComic = iRandomComic;

        var doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        while (doesComicExist == false)
        {
            iRandomComic = oRandomComic.Next(0, iLatestComic + 1);
            iCurrentComic = iRandomComic;
            doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.TotalNumber == (iCurrentComic));
        ImageButton1.ImageUrl = comicImage.FilePath;       

    }




    protected void LinkButtonNext_Click(object sender, EventArgs e)
    {

        if (iCurrentComic < iLatestComic)
        {
            iCurrentComic++;
        }

        var doescomicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        while (doescomicActuallyExist == false)
        {
            iCurrentComic--;
            if (iCurrentComic < 0)
            {
                iCurrentComic = iFirstComic;
            }

            doescomicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicImage.FilePath;

    }






    protected void LinkButtonNewest_Click(object sender, EventArgs e)
    {
        iCurrentComic = iLatestComic;
        ComicData comicImage = db.ComicDatas.Single(c => c.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicImage.FilePath;
        iCurrentComic = iLatestComic;
    }













    //
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (iCurrentComic < iLatestComic)
        {
            iCurrentComic++;
        }

        var doescomicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        while (doescomicActuallyExist == false)
        {
            iCurrentComic--;
            if (iCurrentComic < 0)
            {
                iCurrentComic = iFirstComic;
            }

            doescomicActuallyExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicImage.FilePath;
    }
}
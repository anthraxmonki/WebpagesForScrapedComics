using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExplosmPage : System.Web.UI.Page
{

    static Random oRandomComic = new Random();
    static int iRandomComic = 0;

    static int iFirstComic = 0;
    static int iLatestComic = 3040;
    static int iCurrentComic = iLatestComic;

    static string sComicName = "Explosm";

    static ComicsDBDataContext db = new ComicsDBDataContext();






    //Grab the latest comic first
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            ComicData comicImage = db.ComicDatas.Single(o => o.FileName == (sComicName + Convert.ToString(iCurrentComic)));
            ImageButton1.ImageUrl = comicImage.FilePath;
        }




    }


    protected void LinkButtonFirst_Click(object sender, EventArgs e)
    {

        var doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals(sComicName + Convert.ToString(iFirstComic)));
        while (doesComicActuallyExist == false)
        {
            iFirstComic++;
            doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals(sComicName + Convert.ToString(iFirstComic)));
        }


        ComicData comicImage = db.ComicDatas.Single(c => c.FileName == (sComicName + Convert.ToString(iFirstComic)));
        ImageButton1.ImageUrl = comicImage.FilePath;
        iCurrentComic = iFirstComic;
    }






    //Decrement to the next lowest comic filename
    //    check to see decrement isn't below the very first comic
    protected void LinkButtonPrevious_Click(object sender, EventArgs e)
    {

        if (iCurrentComic >= 0)
        {
            iCurrentComic--;
        }

        var doescomicActuallyExist = db.ComicDatas.Any(o => o.FileName.Equals(sComicName + Convert.ToString(iCurrentComic)));
        while (doescomicActuallyExist == false)
        {
            iCurrentComic--;
            if (iCurrentComic < 0)
            {
                iCurrentComic = iFirstComic;
            }

            doescomicActuallyExist = db.ComicDatas.Any(o => o.FileName.Equals(sComicName + Convert.ToString(iCurrentComic)));
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.FileName == (sComicName + Convert.ToString(iCurrentComic)));
        ImageButton1.ImageUrl = comicImage.FilePath;

    }






    protected void LinkButtonRandom_Click(object sender, EventArgs e)
    {
        iRandomComic = oRandomComic.Next(0, iLatestComic + 1);
        var doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals(sComicName + Convert.ToString(iRandomComic)));

        while (doesComicActuallyExist == false)
        {
            iRandomComic = oRandomComic.Next(0, iLatestComic + 1);
            doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals(sComicName + Convert.ToString(iRandomComic)));
        }


        ComicData comicImage = db.ComicDatas.Single(c => c.FileName == (sComicName + Convert.ToString(iRandomComic)));
        ImageButton1.ImageUrl = comicImage.FilePath;
        iCurrentComic = iRandomComic;
    }




    protected void LinkButtonNext_Click(object sender, EventArgs e)
    {
        iCurrentComic++;
        if (iCurrentComic > iLatestComic)
        {
            iCurrentComic = iLatestComic;
        }
        var doesComicActuallyExist = db.ComicDatas.Any(o => o.FileName.Equals(sComicName + Convert.ToString(iCurrentComic)));
        while (doesComicActuallyExist == false)
        {
            iCurrentComic++;
            doesComicActuallyExist = db.ComicDatas.Any(o => o.FileName.Equals(sComicName + Convert.ToString(iCurrentComic)));
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.FileName == (sComicName + Convert.ToString(iCurrentComic)));
        ImageButton1.ImageUrl = comicImage.FilePath;

    }






    protected void LinkButtonLast_Click(object sender, EventArgs e)
    {

        ComicData comicImage = db.ComicDatas.Single(c => c.FileName == (sComicName + Convert.ToString(iLatestComic)));
        ImageButton1.ImageUrl = comicImage.FilePath;
        iCurrentComic = iLatestComic;
    }







    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        iCurrentComic++;
        if (iCurrentComic > iLatestComic)
        {
            iCurrentComic = iLatestComic;
        }
        var doesComicActuallyExist = db.ComicDatas.Any(o => o.FileName.Equals(sComicName + Convert.ToString(iCurrentComic)));
        while (doesComicActuallyExist == false)
        {
            iCurrentComic++;
            doesComicActuallyExist = db.ComicDatas.Any(o => o.FileName.Equals(sComicName + Convert.ToString(iCurrentComic)));
        }

        ComicData comicImage = db.ComicDatas.Single(o => o.FileName == (sComicName + Convert.ToString(iCurrentComic)));
        ImageButton1.ImageUrl = comicImage.FilePath;
    }





//
}
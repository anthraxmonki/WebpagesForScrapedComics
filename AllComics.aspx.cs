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
    static int iBumps;
    static int iLabelUpdatedBumps;

    static ComicsDBDataContext db = new ComicsDBDataContext();
    static ComicData comicData = new ComicData();




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

            comicData = db.ComicDatas.Single(o => o.TotalNumber == (iCurrentComic));
            ImageButton1.ImageUrl = comicData.FilePath;

            Label1.Text = Convert.ToString(comicData.Bumps);
        }

        if (IsPostBack == true)
        {
            Label1.Text = Convert.ToString(comicData.Bumps);
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

        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicData.FilePath;
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

        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicData.FilePath;
        iLabelUpdatedBumps = comicData.Bumps;

    }


    //
    //
    //
    //
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

        comicData = db.ComicDatas.Single(o => o.TotalNumber == (iCurrentComic));
        ImageButton1.ImageUrl = comicData.FilePath;


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

        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicData.FilePath;

    }






    protected void LinkButtonNewest_Click(object sender, EventArgs e)
    {
        iCurrentComic = iLatestComic;
        comicData = db.ComicDatas.Single(c => c.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicData.FilePath;
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

        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        ImageButton1.ImageUrl = comicData.FilePath;
    }













    protected void LinkButtonLike_Click(object sender, EventArgs e)
    {



        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        comicData.Bumps++;
        iLabelUpdatedBumps = comicData.Bumps;
        db.SubmitChanges();

    }







    //get lowest number of bumps.
    //then increment comics until there are no more bumps
    //then get the first of the inceremented bump.
    //rinse & repeat
    protected void LinkButtonLeastLiked_Click(object sender, EventArgs e)
    {
        iBumps = 0;
        iCurrentComic = 0;



        var doesBumpExist = db.ComicDatas.Any(o => o.Bumps == iBumps);
        while (doesBumpExist == false)
        {
            iBumps++;
            doesBumpExist = db.ComicDatas.Any(o => o.Bumps == iBumps);
        }




        var doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic
                                               && o.Bumps == iBumps);
        while (doesComicExist == false)
        {
            iCurrentComic++;
            doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic
                                               && o.Bumps == iBumps);
        }




        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic
                                                   && o.Bumps == iBumps);

        ImageButton1.ImageUrl = comicData.FilePath;

    }







    protected void LinkButtonMostLiked_Click(object sender, EventArgs e)
    {
        var maxBump = db.ComicDatas.Max(o => o.Bumps);
        iBumps = maxBump;

        var maxComic = db.ComicDatas.Max(o => o.TotalNumber);
        iCurrentComic = maxComic;


        var doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic
                                               && o.Bumps == iBumps);
        while (doesComicExist == false)
        {
            iCurrentComic--;
            doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic
                                               && o.Bumps == iBumps);
        }


        comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic
                                                   && o.Bumps == iBumps);

        ImageButton1.ImageUrl = comicData.FilePath;
        iLabelUpdatedBumps = comicData.Bumps;

    }

  
}
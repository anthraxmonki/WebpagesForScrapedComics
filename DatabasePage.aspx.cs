using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;



//TO-DO
//Create a log of files which don't render -- "missing" .pngs,
//empty files, etc.

//Chase's files are .jpg vs .png so the scraper didn't scrape it
//http://explosm.net/comics/1161/
//http://explosm.net/comics/1163/
//http://explosm.net/comics/1165/
//http://explosm.net/comics/1166/
//http://explosm.net/comics/1167/
//http://explosm.net/comics/1168/
//http://explosm.net/comics/1169/



//TO-DO
//Create the Bump button.
//Sort comics by Bumps
//
//
//
//










public partial class DatabasePage : System.Web.UI.Page
{

    private static int iFirstComic = 1000;
    private static int iLastComic  = 3040;
    private static int iCurrentComic;

    ComicsDBDataContext db = new ComicsDBDataContext();

    static Random oRandomComic = new Random();
    private static int iRandomComic = oRandomComic.Next(iFirstComic, iLastComic);




    protected void Page_Load(object sender, EventArgs e)
    {
        //Grabs and verifies the file path of the needed comic
        //grabs a random Explosm comic


        if (IsPostBack == false)
        {
            //ComicsDBDataContext db = new ComicsDBDataContext();

            //Random oRandomComic = new Random();
            //int iRandomComic = oRandomComic.Next(1000, 3041);


            var doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iRandomComic)));
            
            while (doesComicActuallyExist == false)
            {

                iRandomComic = oRandomComic.Next(iFirstComic, iLastComic);
                doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iRandomComic)));

            }


            ComicData comic = db.ComicDatas.Single(c => c.FileName == ("Explosm" + Convert.ToString(iRandomComic)));
            ImageButton1.ImageUrl = comic.FilePath;

            iCurrentComic = iRandomComic;
        }

    }





    protected void LinqButton_Click(object sender, EventArgs e)
    {
        //ComicsDBDataContext db = new ComicsDBDataContext();

        string sDirectory    = @"~\Comics\Explosm\";

        int iIncrementFrom    = 1210;
        int iIncrementTo      = 3040;

        //ComicData columns
        string sFileName      = "Explosm";
        string sFileExtension = ".png";
        string sWebsite       = "Explosm";
        int    iBumps         = 0;
        string sAbsolutePath = (sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);


        DateTime oDateNow = DateTime.Now;



        //This is how the webpage determines if the filepath exists because
        //(System.IO.File.Exists() doesn't work the way I try to use it)
        string sCompleteFilePath = HttpContext.Current.Server.MapPath(sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);



            do
            {
                //checks to see if the directory file even exists, if not then skip && increment
                if(System.IO.File.Exists(sCompleteFilePath) == true)
                {        

                    //returns true if there if FileName exists in the database.
                    var hasName = db.ComicDatas.Any(p => p.FileName.Equals(sFileName + Convert.ToString(iIncrementFrom)) );

                    //if the FileName does not exist in the column
                    if (hasName == false)
                    {

                        ComicData oColumn = new ComicData();

                        oColumn.FileName = (sFileName + Convert.ToString(iIncrementFrom));
                        oColumn.FileExtension = sFileExtension;
                        oColumn.Website = sWebsite;
                        oColumn.Bumps = iBumps;
                        oColumn.FilePath = sAbsolutePath;
                        oColumn.DateAdded = oDateNow;


                        db.ComicDatas.InsertOnSubmit(oColumn);
                        db.SubmitChanges();
                    }
                }


                iIncrementFrom += 1;

                //re-bind with the incremented data
                sCompleteFilePath = HttpContext.Current.Server.MapPath(sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);
                //re-bind with the incremented data
                sAbsolutePath = (sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);


           } while (iIncrementFrom <= iIncrementTo);


    }






    protected void AnticsLinqButton_Click(object sender, EventArgs e)
    {
        //ComicsDBDataContext db = new ComicsDBDataContext();

        string sDirectory = @"~\Comics\Antics\";

        int iIncrementFrom = 4;
        int iIncrementTo   = 2260;

        //ComicData columns
        string sFileName = "Antics";
        string sFileExtension = ".png";
        string sWebsite = "Antics";
        int iBumps = 0;
        string sAbsolutePath = (sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);

        DateTime oDateNow = DateTime.Now;



        //This is how the webpage determines if the filepath exists because
        //(System.IO.File.Exists() doesn't work the way I try to use it)
        string sCompleteFilePath = HttpContext.Current.Server.MapPath(sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);

        do
        {
            //checks to see if the directory file even exists, if not then skip && increment
            if (System.IO.File.Exists(sCompleteFilePath) == true)
            {
                //returns true if there if FileName exists in the database.
                var hasName = db.ComicDatas.Any(p => p.FileName.Equals(sFileName + Convert.ToString(iIncrementFrom)));
                if (hasName == false)
                {
                    ComicData oColumn = new ComicData();

                    oColumn.FileName = (sFileName + Convert.ToString(iIncrementFrom));
                    oColumn.FileExtension = sFileExtension;
                    oColumn.Website = sWebsite;
                    oColumn.Bumps = iBumps;
                    oColumn.FilePath = sAbsolutePath;
                    oColumn.DateAdded = oDateNow;

                    db.ComicDatas.InsertOnSubmit(oColumn);
                    db.SubmitChanges();
                }
            }
            iIncrementFrom += 1;

            //re-bind with the incremented data
            sCompleteFilePath = HttpContext.Current.Server.MapPath(sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);
            //re-bind with the incremented data
            sAbsolutePath = (sDirectory + sFileName + Convert.ToString(iIncrementFrom) + sFileExtension);
        } while (iIncrementFrom <= iIncrementTo);

    }









    protected void LinkButtonFirst_Click(object sender, EventArgs e)
    {
        ComicData comic = db.ComicDatas.Single(c => c.FileName == ("Explosm" + Convert.ToString(iFirstComic)));
        ImageButton1.ImageUrl = comic.FilePath;

        iCurrentComic = iFirstComic;

    }







    protected void LinkButtonPrevious_Click(object sender, EventArgs e)
    {
        iCurrentComic -= 1;

        var doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iRandomComic)));

        while (doesComicActuallyExist == false)
        {

            iCurrentComic -= 1;
            doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iCurrentComic)));

        }

        ComicData comic = db.ComicDatas.Single(c => c.FileName == ("Explosm" + Convert.ToString(iCurrentComic)));
        ImageButton1.ImageUrl = comic.FilePath;

    }






    protected void LinkButtonRandom_Click(object sender, EventArgs e)
    {
        //ComicsDBDataContext db = new ComicsDBDataContext();

        //Random oRandomComic = new Random();
        //int iRandomComic = oRandomComic.Next(1000, 3041);


        var doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iRandomComic)));

        while (doesComicActuallyExist == false)
        {

            iRandomComic = oRandomComic.Next(iFirstComic, iLastComic);
            doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iRandomComic)));

        }

        ComicData comic = db.ComicDatas.Single(c => c.FileName == ("Explosm" + Convert.ToString(iRandomComic)));
        ImageButton1.ImageUrl = comic.FilePath;

        iCurrentComic = iRandomComic;
    }







    protected void LinkButtonNext_Click(object sender, EventArgs e)
    {
        iCurrentComic += 1;

        var doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iCurrentComic)));

        while (doesComicActuallyExist == false)
        {

            iCurrentComic += 1;
            doesComicActuallyExist = db.ComicDatas.Any(c => c.FileName.Equals("Explosm" + Convert.ToString(iCurrentComic)));

        }

        ComicData comic = db.ComicDatas.Single(c => c.FileName == ("Explosm" + Convert.ToString(iCurrentComic)));
        ImageButton1.ImageUrl = comic.FilePath;
    }







    protected void LinkButtonNewest_Click(object sender, EventArgs e)
    {

        ComicData comic = db.ComicDatas.Single(c => c.FileName == ("Explosm" + Convert.ToString(iLastComic)));
        ImageButton1.ImageUrl = comic.FilePath;

        iCurrentComic = iLastComic;
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LinkButtonNext_Click(sender, e);
    }


}
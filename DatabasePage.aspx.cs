using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;



//TO-DO

//Create a log of files which don't render "missing" .pngs,
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
    Random oRandomComic = new Random();
    int iRandomComic = 0;

    const int iFirstComic = 1;
    int iLatestComic = 2286;
    int iCurrentComic;


    ComicsDBDataContext db = new ComicsDBDataContext();



    protected void Page_Load(object sender, EventArgs e)
    {
  

    }




    //Click me to add comics to the database
    protected void ExplosmButton_Click(object sender, EventArgs e)
    {

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





    //Click me to add Antics comic's tot he database
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







    protected void Button1_Click(object sender, EventArgs e)
    {
        iCurrentComic = iFirstComic;

        var doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        if (doesComicExist == false)
        {
            iCurrentComic++;
            doesComicExist = db.ComicDatas.Any(o => o.TotalNumber == iCurrentComic);
        }

        ComicData comicData = db.ComicDatas.Single(o => o.TotalNumber == iCurrentComic);
        comicData.Bumps++;
        db.SubmitChanges();

        


    }




}
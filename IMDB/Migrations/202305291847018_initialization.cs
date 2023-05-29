namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Description = c.String(),
                        ActorIMG = c.Binary(),
                        LastName = c.String(nullable: false),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.ActorID);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        ActorID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActorID, t.MovieID })
                .ForeignKey("dbo.Actors", t => t.ActorID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.ActorID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        MovieIMG = c.Binary(),
                        Description = c.String(),
                        DirectorID = c.Int(),
                    })
                .PrimaryKey(t => t.MovieID)
                .ForeignKey("dbo.Directors", t => t.DirectorID)
                .Index(t => t.DirectorID);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Description = c.String(),
                        DirectorIMG = c.Binary(),
                        LastName = c.String(nullable: false),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.DirectorID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        MovieID = c.Int(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Movies", t => t.MovieID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.MovieID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ProfileIMG = c.Binary(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        MovieID = c.Int(),
                        LikeValue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.UserFavoriteActors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        ActorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.ActorID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ActorID);
            
            CreateTable(
                "dbo.UserFavoriteDirectors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        DirectorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Directors", t => t.DirectorID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.DirectorID);
            
            CreateTable(
                "dbo.UserFavoriteMovies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        MovieID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFavoriteMovies", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteMovies", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.UserFavoriteDirectors", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteDirectors", "DirectorID", "dbo.Directors");
            DropForeignKey("dbo.UserFavoriteActors", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserFavoriteActors", "ActorID", "dbo.Actors");
            DropForeignKey("dbo.Likes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Likes", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "DirectorID", "dbo.Directors");
            DropForeignKey("dbo.MovieActors", "ActorID", "dbo.Actors");
            DropIndex("dbo.UserFavoriteMovies", new[] { "MovieID" });
            DropIndex("dbo.UserFavoriteMovies", new[] { "UserID" });
            DropIndex("dbo.UserFavoriteDirectors", new[] { "DirectorID" });
            DropIndex("dbo.UserFavoriteDirectors", new[] { "UserID" });
            DropIndex("dbo.UserFavoriteActors", new[] { "ActorID" });
            DropIndex("dbo.UserFavoriteActors", new[] { "UserID" });
            DropIndex("dbo.Likes", new[] { "MovieID" });
            DropIndex("dbo.Likes", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "MovieID" });
            DropIndex("dbo.Movies", new[] { "DirectorID" });
            DropIndex("dbo.MovieActors", new[] { "MovieID" });
            DropIndex("dbo.MovieActors", new[] { "ActorID" });
            DropTable("dbo.UserFavoriteMovies");
            DropTable("dbo.UserFavoriteDirectors");
            DropTable("dbo.UserFavoriteActors");
            DropTable("dbo.Likes");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Directors");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Actors");
        }
    }
}

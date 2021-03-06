//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public partial class Song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Song()
        {
            this.PlayLists = new HashSet<PlayList>();
        }

        private string title;
        private string artistName;
        private int? albumId;
        private int? sequenceId;
        private string pathToFile;
        private int? rating;
        private DateTime year;
        private string genre;
        private string description;

        public Song(string title, string artist, int albumId, int sequenceId, string description, string filePath, uint year, string genre, int rating)
        {
            Title = title;
            ArtistName = artist;
            AlbumId = albumId;
            SequenceId = sequenceId;
            Description = description;
            PathToFile = filePath;
            try
            {
                Year = DateTime.ParseExact(year.ToString(), "yyyy", null);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                Year = new DateTime(1900, 01, 01);
            }
            Genre = genre;
            Rating = rating;
        }

        public int Id { get; set; }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string ArtistName
        {
            get
            {
                return this.artistName;
            }
            set
            {
                this.artistName = value;
            }
        }
        public Nullable<int> AlbumId
        {
            get
            {
                return this.albumId;
            }
            set
            {
                this.albumId = value;
            }
        }
        public Nullable<int> SequenceId
        {
            get
            {
                return this.sequenceId;
            }
            set
            {
                this.sequenceId = value;
            }
        }
        public string PathToFile
        {
            get
            {
                return this.pathToFile;
            }
            set
            {
                Match match = Regex.Match(value, @"^(.+)\\([^\\]+)$");
                if (match.Success)
                {
                    this.pathToFile = value;
                }
                else
                {
                    throw new ArgumentNullException(value, "Path cannot be null or empty");
                }
            }
        }
        public System.DateTime Year
        {
            get
            {
                return this.year;
            }
            set
            {
                if (value.Year > 2099 || value.Year < 1900)
                {
                    throw new ArgumentOutOfRangeException("Year", value.Year, "Year should between 1900 and 2099");
                }
                else
                {
                    this.year = value;
                }
                
            }
        }
        public string Genre
        {
            get
            {
                return this.genre;
            }
            set
            {
                this.genre = value;
            }
        }
        public Nullable<int> Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                this.rating = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
    
        public virtual Album Album { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}

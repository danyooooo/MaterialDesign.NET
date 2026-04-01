using System;
using System.Collections.Generic;

namespace MaterialDesign.NET.Helpers
{
    /// <summary>
    /// Provides access to all Material Symbols icon names.
    /// Use these names with SymbolIcon.Symbol property.
    /// </summary>
    public static class MaterialSymbols
    {
        // Common Icons - Most frequently used
        public const string Home = "home";
        public const string Settings = "settings";
        public const string Account = "account_circle";
        public const string Search = "search";
        public const string Menu = "menu";
        public const string Close = "close";
        public const string Add = "add";
        public const string Edit = "edit";
        public const string Delete = "delete";
        public const string Check = "check";
        public const string Cancel = "cancel";
        public const string Save = "save";
        public const string Upload = "upload";
        public const string Download = "download";
        public const string Share = "share";
        public const string MoreVert = "more_vert";
        public const string MoreHoriz = "more_horiz";
        
        // Navigation Icons
        public const string ArrowBack = "arrow_back";
        public const string ArrowForward = "arrow_forward";
        public const string ArrowUpward = "arrow_upward";
        public const string ArrowDownward = "arrow_downward";
        public const string ArrowLeft = "arrow_left";
        public const string ArrowRight = "arrow_right";
        public const string ChevronLeft = "chevron_left";
        public const string ChevronRight = "chevron_right";
        public const string ExpandLess = "expand_less";
        public const string ExpandMore = "expand_more";
        
        // Action Icons
        public const string Favorite = "favorite";
        public const string FavoriteBorder = "favorite_border";
        public const string Star = "star";
        public const string StarBorder = "star_border";
        public const string Info = "info";
        public const string Help = "help";
        public const string Warning = "warning";
        public const string Error = "error";
        public const string CheckCircle = "check_circle";
        public const string Report = "report";
        
        // Communication Icons
        public const string Email = "email";
        public const string Message = "message";
        public const string Chat = "chat";
        public const string Phone = "phone";
        public const string Notifications = "notifications";
        public const string NotificationsActive = "notifications_active";
        
        // Content Icons
        public const string Description = "description";
        public const string Folder = "folder";
        public const string FolderOpen = "folder_open";
        public const string AttachFile = "attach_file";
        public const string ContentCopy = "content_copy";
        public const string ContentPaste = "content_paste";
        public const string ContentCut = "content_cut";
        
        // Device Icons
        public const string Smartphone = "smartphone";
        public const string Laptop = "laptop";
        public const string Desktop = "desktop_windows";
        public const string Tablet = "tablet";
        public const string Watch = "watch";
        
        // File Icons
        public const string InsertDriveFile = "insert_drive_file";
        public const string PictureAsPdf = "picture_as_pdf";
        public const string Image = "image";
        public const string VideoLibrary = "video_library";
        public const string Audiotrack = "audiotrack";
        
        // Hardware Icons
        public const string Print = "print";
        public const string CameraAlt = "camera_alt";
        public const string Videocam = "videocam";
        public const string Mic = "mic";
        public const string MicOff = "mic_off";
        
        // Image Icons
        public const string Photo = "photo";
        public const string PhotoLibrary = "photo_library";
        public const string ImageSearch = "image_search";
        public const string Crop = "crop";
        public const string Filter = "filter_list";
        
        // Maps Icons
        public const string LocationOn = "location_on";
        public const string LocationOff = "location_off";
        public const string Directions = "directions";
        public const string Map = "map";
        public const string Public = "public";
        
        // Social Icons
        public const string Person = "person";
        public const string PersonAdd = "person_add";
        public const string Group = "group";
        public const string ThumbUp = "thumb_up";
        public const string ThumbDown = "thumb_down";
        
        // Toggle Icons
        public const string Visibility = "visibility";
        public const string VisibilityOff = "visibility_off";
        public const string Lock = "lock";
        public const string LockOpen = "lock_open";
        public const string CheckCircleOutline = "check_circle_outline";
        
        // Utility Icons
        public const string Refresh = "refresh";
        public const string Sync = "sync";
        public const string Schedule = "schedule";
        public const string History = "history";
        public const string TrendingUp = "trending_up";
        public const string TrendingDown = "trending_down";
        
        // Shopping Icons
        public const string ShoppingCart = "shopping_cart";
        public const string ShoppingBag = "shopping_bag";
        public const string CreditCard = "credit_card";
        public const string Payment = "payment";
        
        // Editor Icons
        public const string FormatBold = "format_bold";
        public const string FormatItalic = "format_italic";
        public const string FormatUnderlined = "format_underlined";
        public const string FormatListBulleted = "format_list_bulleted";
        public const string FormatListNumbered = "format_list_numbered";
        
        /// <summary>
        /// Gets a list of all available icon names.
        /// </summary>
        public static IReadOnlyList<string> GetAllIcons()
        {
            return new List<string>
            {
                Home, Settings, Account, Search, Menu, Close, Add, Edit, Delete, Check, Cancel,
                Save, Upload, Download, Share, MoreVert, MoreHoriz, ArrowBack, ArrowForward,
                ArrowUpward, ArrowDownward, ArrowLeft, ArrowRight, ChevronLeft, ChevronRight,
                ExpandLess, ExpandMore, Favorite, FavoriteBorder, Star, StarBorder, Info, Help,
                Warning, Error, CheckCircle, Report, Email, Message, Chat, Phone, Notifications,
                NotificationsActive, Description, Folder, FolderOpen, AttachFile, ContentCopy,
                ContentPaste, ContentCut, Smartphone, Laptop, Desktop, Tablet, Watch,
                InsertDriveFile, PictureAsPdf, Image, VideoLibrary, Audiotrack, Print, CameraAlt,
                Videocam, Mic, MicOff, Photo, PhotoLibrary, ImageSearch, Crop, Filter, LocationOn,
                LocationOff, Directions, Map, Public, Person, PersonAdd, Group, ThumbUp, ThumbDown,
                Visibility, VisibilityOff, Lock, LockOpen, CheckCircleOutline, Refresh, Sync,
                Schedule, History, TrendingUp, TrendingDown, ShoppingCart, ShoppingBag, CreditCard,
                Payment, FormatBold, FormatItalic, FormatUnderlined, FormatListBulleted, FormatListNumbered
            }.AsReadOnly();
        }
    }
}

﻿using System.Linq;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Type
{
    /// <summary>
    /// This object represents one size of a photo or a file/sticker thumbnail.
    /// See <see href="https://core.telegram.org/bots/api#photosize">API</see>
    /// </summary>
    public class PhotoSizeInfo
    {
        internal PhotoSizeInfo()
        {
        }
        
        internal PhotoSizeInfo(JObject jsonObject)
        {
            FileId = jsonObject["file_id"].Value<string>();
            Width = jsonObject["width"].Value<int>();
            Height = jsonObject["height"].Value<int>();

            if (jsonObject["file_size"] != null)
                FileSize = jsonObject["file_size"].Value<int>();
        }

        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Photo width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Photo height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public int FileSize { get; set; }

        internal static PhotoSizeInfo[] ParseArray(JArray jsonArray)
        {
            return jsonArray.Cast<JObject>().Select(jobject => new PhotoSizeInfo(jobject)).ToArray();
        }
    }
}

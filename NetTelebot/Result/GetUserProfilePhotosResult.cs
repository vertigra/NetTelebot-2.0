﻿using NetTelebot.Type;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetTelebot.Result
{
    /// <summary>
    /// When calling GetUserProfilePhotos method on TelegramBotClient class, this object will be returned.
    /// </summary>
    public class GetUserProfilePhotosResult
    {
        internal GetUserProfilePhotosResult(string jsonText)
        {
            var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonText);
            Parse(jsonObject);
        }

        private void Parse(JObject jsonObject)
        {
            Ok = jsonObject["ok"].Value<bool>();
            Result = new UserProfilePhotosInfo(jsonObject["result"].Value<JObject>());
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="GetUserProfilePhotosResult"/> is ok.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ok; otherwise, <c>false</c>.
        /// </value>
        public bool Ok { get; private set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result is instance of the <see cref="UserProfilePhotosInfo"/> class
        /// </value>
        public UserProfilePhotosInfo Result { get; private set; }
    }
}

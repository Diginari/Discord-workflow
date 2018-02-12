using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Attributes;
using Umbraco.Forms.Core.Enums;

namespace Discord_Workflow
{
    public class PostToDiscord : WorkflowType
    {
        [Setting("Discord Webhook URL", description = "The URL to the discord webhook", view = "textfield")]
        public string DiscordWebhookUrl { get; set; }

        [Setting("Discord Content", description = "The content to be sent to discord", view = "textarea")]
        public string ContentData { get; set; }

        public PostToDiscord()
        {
            this.Id = new Guid("4F97E6AF-9AFF-48FF-BC4B-25E983878A75");
            this.Name = "Post to Discord";
            this.Description = "Post the form result to Discord";
            this.Icon = "icon-stream";
        }

        public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
        {
            var payload = new Payload()
            {
                Content = ContentData
            };

            var payloadJson = JsonConvert.SerializeObject(payload);
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString(DiscordWebhookUrl, "POST", payloadJson);
            }

            return WorkflowExecutionStatus.Completed;
        }

        public override List<Exception> ValidateSettings()
        {
            var exceptions = new List<Exception>();

            if (string.IsNullOrEmpty(DiscordWebhookUrl))
                exceptions.Add(new Exception("'Discord Webhook URL' setting has not been set"));

            if (string.IsNullOrEmpty(ContentData))
                exceptions.Add(new Exception("'Discord Content' setting has not been set"));

            return exceptions;
        }

        public class Payload
        {
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }
}
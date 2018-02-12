# Discord-workflow

This workflow enables you to post the results of a form to Discord.

Firstly you need to create a webhook for the channel you want to receive the form. Click the cog next to the channel to edit that channel, then click on 'Webhooks', configure the details for the bot such as it's name, channel and an icon if you wish. 
You will then be given a URL, copy this to your clipboard or click the 'Copy' button and click Save.

Now install the Discord-workflow package if you have not yet done so. 

You are now free to add the workflow to your form. Upon adding it you will be asked for a webhook URL and the content. Paste the URL you copied earlier into the Webhook URL field and then enter the content you would like posted to the Discord channel. You are free to use any of the form values inside this. For example, if you have a contact form and you want to post the results, use this.

A new contact request has been submitted
```Name: {yourname}
Email: {youremail}
Message: {yourmessage}
```

For discord formatting information, see this page:
https://support.discordapp.com/hc/en-us/articles/210298617-Markdown-Text-101-Chat-Formatting-Bold-Italic-Underline-

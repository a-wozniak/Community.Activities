﻿using System.Activities.Presentation.Metadata;
using System.Activities.Presentation.View.OutlineView;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using UiPath.FTP.Activities.Design.Properties;
using UiPath.Studio.Activities.Api;

namespace UiPath.FTP.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        /// <summary>
        /// Help link template
        /// </summary>
        private const string UrlWorkflowActivitiesDocsTemplate = "https://docs.uipath.com/activities/lang-{0}/docs/{1}";

        /// <summary>
        /// Calls the Initialize method which will handle the registration of synonyms
        /// </summary>
        /// <param name="api"></param>
        private void InitializeInternal(object api)
        {
            if (api is IWorkflowDesignApi wfDesignApi)
            {
                new ActivitySynonymApiRegistration().Initialize(wfDesignApi);
            }
        }

        /// <summary>
        /// Calls the private method which will handle the registration of synonyms
        /// </summary>
        /// <param name="api"></param>
        public void Initialize(object api)
        {
            if (api == null)
            {
                return;
            }
            InitializeInternal(api);
        }

        public void Register()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();
            ShowPropertyInOutlineViewAttribute hideFromOutlineAttribute = new ShowPropertyInOutlineViewAttribute() { CurrentPropertyVisible = false, DuplicatedChildNodesVisible = false };



            builder.AddCustomAttributes(typeof(WithFtpSession), new DesignerAttribute(typeof(WithFtpSessionDesigner)));
            builder.AddCustomAttributes(typeof(MoveItem), new DesignerAttribute(typeof(MoveItemsDesigner)));
            builder.AddCustomAttributes(typeof(DownloadFiles), new DesignerAttribute(typeof(DownloadFilesDesigner)));
            builder.AddCustomAttributes(typeof(UploadFiles), new DesignerAttribute(typeof(UploadFilesDesigner)));
            builder.AddCustomAttributes(typeof(Delete), new DesignerAttribute(typeof(DeleteDesigner)));
            builder.AddCustomAttributes(typeof(DirectoryExists), new DesignerAttribute(typeof(DirectoryExistsDesigner)));
            builder.AddCustomAttributes(typeof(EnumerateObjects), new DesignerAttribute(typeof(EnumerateObjectsDesigner)));
            builder.AddCustomAttributes(typeof(FileExists), new DesignerAttribute(typeof(FileExistsDesigner)));

            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.Body), hideFromOutlineAttribute);

            // Category
            CategoryAttribute FTPCategoryAttribute =
               new CategoryAttribute($"{Resources.CategoryAppIntegration}.{Resources.CategoryFTP}");
            builder.AddCustomAttributes(typeof(Delete), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(DirectoryExists), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(DownloadFiles), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(EnumerateObjects), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(FileExists), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(MoveItem), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(UploadFiles), FTPCategoryAttribute);
            builder.AddCustomAttributes(typeof(WithFtpSession), FTPCategoryAttribute);

            // Activities DisplayName
            builder.AddCustomAttributes(typeof(Delete), new DisplayNameAttribute(SharedResources.Activity_Delete_Name));
            builder.AddCustomAttributes(typeof(DirectoryExists), new DisplayNameAttribute(SharedResources.Activity_DirectoryExists_Name));
            builder.AddCustomAttributes(typeof(DownloadFiles), new DisplayNameAttribute(SharedResources.Activity_DownloadFiles_Name));
            builder.AddCustomAttributes(typeof(EnumerateObjects), new DisplayNameAttribute(SharedResources.Activity_EnumerateObjects_Name));
            builder.AddCustomAttributes(typeof(FileExists), new DisplayNameAttribute(SharedResources.Activity_FileExists_Name));
            builder.AddCustomAttributes(typeof(MoveItem), new DisplayNameAttribute(SharedResources.Activity_MoveItem_Name));
            builder.AddCustomAttributes(typeof(UploadFiles), new DisplayNameAttribute(SharedResources.Activity_UploadFiles_Name));
            builder.AddCustomAttributes(typeof(WithFtpSession), new DisplayNameAttribute(SharedResources.Activity_WithFtpSession_Name));

            // Properties and Descriptions
            var ContinueOnError = new DisplayNameAttribute(SharedResources.ContinueOnError);
            var UsernameDescription = new DescriptionAttribute(SharedResources.UsernameDescription);
            var PasswordDescription = new DescriptionAttribute(SharedResources.PasswordDescription);
            var ClientCertificatePasswordDescription = new DescriptionAttribute(SharedResources.ClientCertificatePasswordDescription);
            var HostDescription = new DescriptionAttribute(SharedResources.HostDescription);
            var PortDescription = new DescriptionAttribute(SharedResources.PortDescription);
            var RemotePathDescription = new DescriptionAttribute(SharedResources.RemotePathDescription);
            var DirectoryExistsDescription = new DescriptionAttribute(SharedResources.DirectoryExistsDescription);
            var FileExistsDescription = new DescriptionAttribute(SharedResources.FileExistsDescription);
            var FilesDescription = new DescriptionAttribute(SharedResources.FilesDescription);
            var MoveItemNewPathDescription = new DescriptionAttribute(SharedResources.NewPathDescription);
            var LocalPathDescription = new DescriptionAttribute(SharedResources.LocalPathDescription);

            //Delete properties
            builder.AddCustomAttributes(typeof(Delete), nameof(Delete.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(Delete), nameof(Delete.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(Delete), new HelpKeywordAttribute(GenerateHelpLinkForActivity("ftp-delete")));

            //DirectoryExists properties
            builder.AddCustomAttributes(typeof(DirectoryExists), nameof(DirectoryExists.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(DirectoryExists), nameof(DirectoryExists.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(DirectoryExists), nameof(DirectoryExists.Exists), DirectoryExistsDescription);
            builder.AddCustomAttributes(typeof(DirectoryExists), new HelpKeywordAttribute(GenerateHelpLinkForActivity("directory-exists")));

            //File properties
            builder.AddCustomAttributes(typeof(FileExists), nameof(FileExists.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(FileExists), nameof(FileExists.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(FileExists), nameof(FileExists.Exists), FileExistsDescription);
            builder.AddCustomAttributes(typeof(FileExists), new HelpKeywordAttribute(GenerateHelpLinkForActivity("file-exists")));

            //MoveItem properties
            builder.AddCustomAttributes(typeof(MoveItem), nameof(MoveItem.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(MoveItem), nameof(MoveItem.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(MoveItem), nameof(MoveItem.NewPath), MoveItemNewPathDescription);
            builder.AddCustomAttributes(typeof(MoveItem), new HelpKeywordAttribute(GenerateHelpLinkForActivity("move-item")));

            //DownloadFiles properties
            builder.AddCustomAttributes(typeof(DownloadFiles), nameof(DownloadFiles.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(DownloadFiles), nameof(DownloadFiles.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(DownloadFiles), nameof(DownloadFiles.LocalPath), LocalPathDescription);
            builder.AddCustomAttributes(typeof(DownloadFiles), new HelpKeywordAttribute(GenerateHelpLinkForActivity("download-files")));

            //EnumerateObjects properties
            builder.AddCustomAttributes(typeof(EnumerateObjects), nameof(EnumerateObjects.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(EnumerateObjects), nameof(EnumerateObjects.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(EnumerateObjects), nameof(EnumerateObjects.Files), FilesDescription);
            //builder.AddCustomAttributes(typeof(EnumerateObjects), new HelpKeywordAttribute(GenerateHelpLinkForActivity("enumerate-objects")));

            //UploadFiles properties
            builder.AddCustomAttributes(typeof(UploadFiles), nameof(UploadFiles.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(UploadFiles), nameof(UploadFiles.LocalPath), LocalPathDescription);
            builder.AddCustomAttributes(typeof(UploadFiles), nameof(UploadFiles.RemotePath), RemotePathDescription);
            builder.AddCustomAttributes(typeof(UploadFiles), new HelpKeywordAttribute(GenerateHelpLinkForActivity("upload-files")));

            // WithFTPSession properties
            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.ContinueOnError), ContinueOnError);
            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.Username), UsernameDescription);
            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.Password), PasswordDescription);
            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.ClientCertificatePassword), ClientCertificatePasswordDescription);
            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.Host), HostDescription);
            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.Port), PortDescription);
            builder.AddCustomAttributes(typeof(WithFtpSession), new HelpKeywordAttribute(GenerateHelpLinkForActivity("with-ftp-session")));

            builder.AddCustomAttributes(typeof(WithFtpSession), nameof(WithFtpSession.UseAnonymousLogin), new DescriptionAttribute(SharedResources.UseAnonymousLoginDescription));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        private static string GenerateHelpLinkForActivity(string activity)
        {
            // Normally, Studio should handle the help link generation. However, this package started with some
            // hardcoded links early on, and kept doing things this way, so we can't really remove them. What we can do
            // instead is generate them in the same way Studio would, based on the language.
            var cultureCode = CultureInfo.CurrentUICulture.Name.Replace("-", "_");
            var activityLink = string.Format(UrlWorkflowActivitiesDocsTemplate, cultureCode, activity);
            return activityLink;
        }

    }
}

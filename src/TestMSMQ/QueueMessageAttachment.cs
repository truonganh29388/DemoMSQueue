using System;
using System.IO;

namespace TestMSMQ
{
    /// <summary>
    /// Class to encapsulate a queue message attachment.
    /// </summary>
    public sealed class QueueMessageAttachment
    {
        // Fields have to be public for XML serialisation.
        /// <summary>
        /// 
        /// </summary>
		public string attachmentName = null;
        /// <summary>
        /// 
        /// </summary>
		public string encodedAttachment = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessageAttachment"/> class.
        /// </summary>
        public QueueMessageAttachment()
            : this(String.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessageAttachment"/> class.
        /// </summary>
        /// <param name="fileName">Filename of the attachment.</param>
        public QueueMessageAttachment(string fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                FileInfo f = new FileInfo(fileName);
                this.attachmentName = f.Name;
                this.encodedAttachment = Convert.ToBase64String(File.ReadAllBytes(fileName),
                    Base64FormattingOptions.InsertLineBreaks);
            }
        }

        /// <summary>
        /// Gets the name of the attachment.
        /// </summary>
        /// <value>The name of the attachment.</value>
        public string Name
        {
            get
            {
                return this.attachmentName;
            }
        }

        /// <summary>
        /// Gets the content of the attachment.
        /// </summary>
        /// <value>The content of the attachment.</value>
        public byte[] Content
        {
            get
            {
                return Convert.FromBase64String(this.encodedAttachment);
            }
        }
    }
}

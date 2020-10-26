using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMSMQ
{
    /// <summary>
    /// Class to encapsulate content of queue messages.
    /// </summary>
    public sealed class QueueMessage
    {
        // Fields have to be public for XML serialisation.
        // Don't mark list as public as it will serialise itself.
        /// <summary>
        /// Get or set the message body.
        /// </summary>
		public string messageBody = null;
        /// <summary>
        /// Get or set the identifier for the user.
        /// </summary>
		public string userId = null;
        /// <summary>
        /// Get or set the reference.
        /// </summary>
		public string reference = null;
        /// <summary>
        /// Get or set the source.
        /// </summary>
		public string source = null;
        /// <summary>
        /// Defines the type of the message
        /// </summary>
        public int messageType = 0;

        private List<QueueMessageAttachment> attachments = new List<QueueMessageAttachment>();

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        public QueueMessage()
            : this(String.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="body">The message body.</param>
        public QueueMessage(string body)
            : this(body, String.Empty, String.Empty, String.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="body">The message body.</param>
        /// <param name="userId">The ID of user sending this message.</param>
        /// <param name="reference">The reference of the message.</param>
        public QueueMessage(string body, string userId, string reference)
            : this(body, userId, reference, String.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="body">The message body.</param>
        /// <param name="userId">The ID of user sending this message.</param>
        /// <param name="reference">The reference of the message.</param>
        /// <param name="source">The source of the message.</param>
        public QueueMessage(string body, string userId, string reference, string source)
            : this(body, String.Empty, userId, reference, source)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="body">The message body.</param>
        /// <param name="attachmentFileName">Name of the attachment file.</param>
        /// <param name="userId">The ID of user sending this message.</param>
        /// <param name="reference">The reference of the message.</param>
        /// <param name="source">The source of the message.</param>
        public QueueMessage(string body, string attachmentFileName, string userId, string reference, string source)
            : this(body, new string[] { attachmentFileName }, userId, reference, source)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        /// <param name="body">The message body.</param>
        /// <param name="attachmentFileNames">List of attachment filenames.</param>
        /// <param name="userId">The ID of user sending this message.</param>
        /// <param name="reference">Reference of the message.</param>
        /// <param name="source">Source of the message.</param>
        public QueueMessage(string body, string[] attachmentFileNames, string userId, string reference, string source)
            : this(body, attachmentFileNames, userId, reference, source, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
		/// <param name="body">The message body.</param>
		/// <param name="attachmentFileNames">List of attachment filenames.</param>
		/// <param name="userId">The ID of user sending this message.</param>
		/// <param name="reference">Reference of the message.</param>
		/// <param name="source">Source of the message.</param>
		/// <param name="type">The type of the message.</param>
        public QueueMessage(string body, string[] attachmentFileNames, string userId, string reference, string source, int type)
        {
            this.messageBody = body;
            this.userId = userId;
            this.reference = reference;
            this.source = source;
            this.messageType = type;

            if ((attachmentFileNames != null) && (attachmentFileNames.Length > 0))
            {
                foreach (string s in attachmentFileNames)
                {
                    this.attachments.Add(new QueueMessageAttachment(s));
                }
            }
        }

        /// <summary>
        /// Gets the message body.
        /// </summary>
        public string Body
        {
            get
            {
                return this.messageBody;
            }
        }

        /// <summary>
        /// Gets the ID for user that send the message.
        /// </summary>
        public string UserId
        {
            get
            {
                return this.userId;
            }
        }

        /// <summary>
        /// Gets the list of message attachments.
        /// </summary>
        public List<QueueMessageAttachment> Attachments
        {
            get
            {
                return this.attachments;
            }
        }

        /// <summary>
        /// Gets true if this message has any attachments, otherwise false.
        /// </summary>
        public bool HasAttachments
        {
            get
            {
                return (this.attachments.Count > 0);
            }
        }

        /// <summary>
        /// Gets the message reference.
        /// </summary>
        public string Reference
        {
            get { return this.reference; }
        }

        /// <summary>
        /// Gets the message source.
        /// </summary>
        public string Source
        {
            get { return this.source; }
        }

        /// <summary>
        /// Returns the type of the message
        /// </summary>
        public int MessageType
        {
            get { return this.messageType; }
        }
    }
}

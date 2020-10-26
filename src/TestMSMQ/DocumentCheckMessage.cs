using System;

namespace TestMSMQ
{
    public sealed class DocumentCheckMessage : PremexMessage
    {
        /// <summary>
        /// Create a new instance of DocumentCheckMessage.
        /// </summary>
        public DocumentCheckMessage()
        {
        }

        #region Properties

        /// <summary>
		/// Gets and sets the guid of the document.
		/// </summary>
        public Guid Guid { get; set; }

        /// <summary>
		/// Gets and sets the name the document.
		/// </summary>
        public string DocumentName { get; set; }

        #endregion

        /// <summary>
        /// Deserializes the message.
        /// </summary>
        /// <param name="xml">A <c>String</c> containing a fragment of XML to de-serialise.</param>
        /// <returns>The DocumentCheckMessage instantiated from the deserialised XML.</returns>
        public static DocumentCheckMessage Deserialize(string xml)
        {
            DocumentCheckMessage message = PremexMessage.OnDeserialize<DocumentCheckMessage>(xml);
            return message;
        }
    }
}

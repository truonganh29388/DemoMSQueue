using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TestMSMQ
{
    public abstract class PremexMessage
    {
        #region Properties

        /// <summary>
        /// Gets and sets the agency identifier.
        /// </summary>
        public int AgencyId { get; set; }

        /// <summary>
        /// Gets and sets the agency case identifier.
        /// </summary>
        public string CaseId { get; set; }

        /// <summary>
        /// Gets and sets a string value indicating any additional information relating to the PremexMessage.
        /// </summary>
        public string AdditionalInformation { get; set; }

        #endregion

        /// <summary>
        /// Serializes the current object.
        /// </summary>
        /// <returns>The xml string.</returns>
        public string Serialise()
        {
            try
            {
                using (StringWriter output = new StringWriter(new StringBuilder()))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(output, this);
                    return output.ToString();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes the message.
        /// </summary>
        /// <typeparam name="T">The type of the message to instantiate. This must derive from PremexMessage.</typeparam>
        /// <param name="xml">A <c>String</c> containing a fragment of XML to de-serialise.</param>
        /// <returns>The PremexMessage instantiated from the deserialised XML.</returns>
        public static T OnDeserialize<T>(string xml) where T : PremexMessage
        {
            T message = null;

            try
            {
                using (StringReader reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    message = (T)serializer.Deserialize(reader);
                }
            }
            catch
            {
                throw;
            }

            return message;
        }
    }
}

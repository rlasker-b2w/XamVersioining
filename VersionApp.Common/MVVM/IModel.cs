using System;

namespace VersionApp.Common.MVVM
{
    public interface IModel
    {
        /// <summary>
        /// Gets or sets the Model identifier.
        /// </summary>
        /// <value>The Model identifier.</value>
        Guid ObjectID { get; set; }

        byte[] DatabaseRowVersion { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToyStoreClientApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalOffer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
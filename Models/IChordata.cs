namespace Pattern.Models
{
    /// <summary>
    /// Тип хордовые содержит в себе классы существ
    /// </summary>
    public abstract class Chordata
    {
        /// <summary>
        /// Имя класса 
        /// </summary>
        public string NameClass { get; set; }

        /// <summary>
        /// Среда обитания
        /// </summary>
        public string LivingEnvironment { get; set; }

        /// <summary>
        /// Численность существ в классе
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Отряд
        /// </summary>
        public string Detachment { get; set; }

        public int ID { get; set; }
    }
}

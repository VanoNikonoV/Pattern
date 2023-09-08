namespace Pattern.Models
{
    /// <summary>
    /// Тип хордовые содержит в себе классы существ
    /// </summary>
    public interface IChordata
    {
        /// <summary>
        /// Имя класса 
        /// </summary>
        string NameClass { get; set; }

        /// <summary>
        /// Среда обитания
        /// </summary>
        string LivingEnvironment { get; set; }

        /// <summary>
        /// Численность существ в классе
        /// </summary>
        int Size { get; set; }
        /// <summary>
        /// Отряд
        /// </summary>
        string Detachment { get; set; }
    }
}

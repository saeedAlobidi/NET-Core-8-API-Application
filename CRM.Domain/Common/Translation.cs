


namespace CRM.Domain.Common;
public abstract class TranslatableEntity<TId, TTranslated,TSource> : Entity<TId>
where TId : struct
where TTranslated : TranslatedEntity<TId, TSource, TTranslated>
 where TSource : TranslatableEntity<TId, TTranslated,TSource>

{
    public ICollection<TTranslated> Translations { get; set; } = new List<TTranslated>();

}

public abstract class TranslatedEntity<TId, TSource, TTranslatable> : Entity<TId>
  where TId : struct
 where TSource : TranslatableEntity<TId, TTranslatable,TSource>
 where TTranslatable : TranslatedEntity<TId, TSource, TTranslatable>


{
    public string LanguageCode { get; set; }
    public TSource Source { get; set; }

}






public interface IReport<T>
{
  void Dump();
  void Stash(T t);

  void Clear();
}



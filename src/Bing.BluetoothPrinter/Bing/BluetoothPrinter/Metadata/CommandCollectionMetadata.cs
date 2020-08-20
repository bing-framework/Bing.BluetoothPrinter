using System.Collections.Generic;

namespace Bing.BluetoothPrinter.Metadata
{
    /// <summary>
    /// 命令行集合元数据
    /// </summary>
    public class CommandCollectionMetadata
    {
        /// <summary>
        /// 索引
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// 命令列表
        /// </summary>
        private readonly List<CommandMetadata> _list;

        /// <summary>
        /// 初始化一个<see cref="CommandCollectionMetadata"/>类型的实例
        /// </summary>
        public CommandCollectionMetadata() : this(null) { }

        /// <summary>
        /// 初始化一个<see cref="CommandCollectionMetadata"/>类型的实例
        /// </summary>
        /// <param name="list">命令列表</param>
        public CommandCollectionMetadata(List<CommandMetadata> list) => _list = list ?? new List<CommandMetadata>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="command">命令</param>
        public void Add(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;
            _list.Add(new CommandMetadata
            {
                Command = command,
                Order = ++_index
            });
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="metadata">命令元数据</param>
        public void Add(CommandMetadata metadata) => Add(metadata.Command);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="metadata">命令集合元数据</param>
        public void Add(CommandCollectionMetadata metadata) => metadata._list.ForEach(Add);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="commands">命令集合</param>
        public void AddRange(List<string> commands)
        {
            foreach (var command in commands)
            {
                if(string.IsNullOrWhiteSpace(command))
                    continue;
                Add(command);
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list">命令元数据集合</param>
        public void AddRange(List<CommandMetadata> list)
        {
            foreach (var command in list) 
                Add(command);
        }

        /// <summary>
        /// 获取命令集合
        /// </summary>
        public IList<CommandMetadata> GetCommands() => this._list;

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() => _list.Clear();
    }
}

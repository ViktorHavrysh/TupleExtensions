using System;
using System.Threading.Tasks;

namespace TupleExtensions
{
    /// <summary>
    /// Extensions that enhance async/await experience by leveranging tuples from C# 7
    /// </summary>
    public static class TupleTaskExtensions
    {
        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />.</param>
        /// <returns></returns>
        public static Task<(T1, T2)> WhenAll<T1, T2>(this (Task<T1>, Task<T2>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result), tasks.Item1, tasks.Item2);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3}"/>.</returns>
        public static Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(this (Task<T1>, Task<T2>, Task<T3>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result), tasks.Item1, tasks.Item2, tasks.Item3);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4}"/>.</returns>
        public static Task<(T1, T2, T3, T4)> WhenAll<T1, T2, T3, T4>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result), tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4, T5}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />, <see cref="Task{T5}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4, T5}"/>.</returns>
        public static Task<(T1, T2, T3, T4, T5)> WhenAll<T1, T2, T3, T4, T5>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result, tasks.Item5.Result), tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4, tasks.Item5);


        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4, T5, T6}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />, <see cref="Task{T5}" />, <see cref="Task{T6}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4, T5, T6}"/>.</returns>
        public static Task<(T1, T2, T3, T4, T5, T6)> WhenAll<T1, T2, T3, T4, T5, T6>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result, tasks.Item5.Result, tasks.Item6.Result),
                tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4, tasks.Item5, tasks.Item6);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />, <see cref="Task{T5}" />, <see cref="Task{T6}" />, <see cref="Task{T7}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7}"/>.</returns>
        public static Task<(T1, T2, T3, T4, T5, T6, T7)> WhenAll<T1, T2, T3, T4, T5, T6, T7>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result, tasks.Item5.Result, tasks.Item6.Result, tasks.Item7.Result),
                tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4, tasks.Item5, tasks.Item6, tasks.Item7);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />, <see cref="Task{T5}" />, <see cref="Task{T6}" />, <see cref="Task{T7}" />, <see cref="Task{T8}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.</returns>
        public static Task<(T1, T2, T3, T4, T5, T6, T7, T8)> WhenAll<T1, T2, T3, T4, T5, T6, T7, T8>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>, Task<T8>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result, tasks.Item5.Result, tasks.Item6.Result, tasks.Item7.Result, tasks.Item8.Result),
                tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4, tasks.Item5, tasks.Item6, tasks.Item7, tasks.Item8);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />, <see cref="Task{T5}" />, <see cref="Task{T6}" />, <see cref="Task{T7}" />, <see cref="Task{T8}" />, <see cref="Task{T9}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.</returns>
        public static Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> WhenAll<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>, Task<T8>, Task<T9>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result, tasks.Item5.Result, tasks.Item6.Result, tasks.Item7.Result, tasks.Item8.Result, tasks.Item9.Result),
                tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4, tasks.Item5, tasks.Item6, tasks.Item7, tasks.Item8, tasks.Item9);

        /// <summary>
        /// Aggregates tuple of tasks into task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.
        /// </summary>
        /// <param name="tasks">Tuple of <see cref="Task{T1}" />, <see cref="Task{T2}" />, <see cref="Task{T3}" />, <see cref="Task{T4}" />, <see cref="Task{T5}" />, <see cref="Task{T6}" />, <see cref="Task{T7}" />, <see cref="Task{T8}" />, <see cref="Task{T9}" />, <see cref="Task{T10}" />.</param>
        /// <returns>Task of <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, T8}"/>.</returns>
        public static Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> WhenAll<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>, Task<T6>, Task<T7>, Task<T8>, Task<T9>, Task<T10>) tasks) =>
            GetAggregatedTask(_ => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result, tasks.Item5.Result, tasks.Item6.Result, tasks.Item7.Result, tasks.Item8.Result, tasks.Item9.Result, tasks.Item10.Result),
                tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4, tasks.Item5, tasks.Item6, tasks.Item7, tasks.Item8, tasks.Item9, tasks.Item10);

        private static Task<T> GetAggregatedTask<T>(Func<Task, T> resultSelector, params Task[] tasks)
        {
            var tcs = new TaskCompletionSource<T>();

            var aggregatedTask = Task.WhenAll(tasks);

            aggregatedTask.ContinueWith(t => tcs.SetResult(resultSelector(t)), TaskContinuationOptions.OnlyOnRanToCompletion);
            aggregatedTask.ContinueWith(_ => tcs.SetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            aggregatedTask.ContinueWith(t => tcs.SetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);

            return tcs.Task;
        }
    }
}

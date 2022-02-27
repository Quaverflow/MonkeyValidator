using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorTestsCollections
{
    #region More

    [Fact]
    public void Test_CountShouldBeMoreThanCountOf_ShouldFail()
    {
        var sut = new List<int>();
        var actual = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeMoreThanCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeMoreThanCountOf_ShouldFail_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeMoreThanCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeMore_ShouldFail()
    {
        var sut = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeMoreThan(3).Execute());
    }

    [Fact]
    public void Test_CountShouldBeMore_ShouldFail_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeMoreThan(2).Execute());
    }

    #endregion

    #region MoreOrEqual

    [Fact]
    public void Test_CountShouldBeMoreOrEqualThanCountOf_ShouldFail()
    {
        var sut = new List<int>();
        var actual = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeMoreOrEqualToCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeMoreOrEqualThanCountOf_ShouldPass_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int> { 3, 5 };
        sut.GetValidator().CountShouldBeMoreOrEqualToCountOf(actual).Execute();
    }

    [Fact]
    public void Test_CountShouldBeMoreOrEqual_ShouldFail()
    {
        var sut = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeMoreOrEqualTo(3).Execute());
    }

    [Fact]
    public void Test_CountShouldBeMoreOrEqual_ShouldPass_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        sut.GetValidator().CountShouldBeMoreOrEqualTo(2).Execute();
    }

    #endregion

    #region Less

    [Fact]
    public void Test_CountShouldBeLessThanCountOf_ShouldFail()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeLessThanCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeLessThanCountOf_ShouldFail_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeLessThanCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeLess_ShouldFail()
    {
        var sut = new List<int> { 3, 5, 5, 6 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeLessThan(3).Execute());
    }

    [Fact]
    public void Test_CountShouldBeLess_ShouldFail_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeLessThan(2).Execute());
    }

    #endregion

    #region LessOrEqual

    [Fact]
    public void Test_CountShouldBeLessOrEqualThanCountOf_ShouldFail()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeLessOrEqualToCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeLessOrEqualThanCountOf_ShouldPass_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int> { 3, 5 };
        sut.GetValidator().CountShouldBeLessOrEqualToCountOf(actual).Execute();
    }

    [Fact]
    public void Test_CountShouldBeLessOrEqual_ShouldFail()
    {
        var sut = new List<int> { 3, 5, 3, 5 };

        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeLessOrEqualTo(3).Execute());
    }

    [Fact]
    public void Test_CountShouldBeLessOrEqual_ShouldPass_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        sut.GetValidator().CountShouldBeMoreOrEqualTo(2).Execute();
    }

    #endregion

    #region ShouldBeEqualTo

    [Fact]
    public void Test_CountShouldBeEqualThanCountOf_ShouldFail()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualToCountOf(actual).Execute());
    }

    [Fact]
    public void Test_CountShouldBeEqualThanCountOf_ShouldPass_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        var actual = new List<int> { 3, 5 };
        sut.GetValidator().CountShouldBeEqualToCountOf(actual).Execute();
    }

    [Fact]
    public void Test_CountShouldBeEqual_ShouldFail()
    {
        var sut = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void Test_CountShouldBeEqual_ShouldPass_ForEqualNumber()
    {
        var sut = new List<int> { 3, 5 };
        sut.GetValidator().CountShouldBeEqualTo(2).Execute();
    }

    #endregion

    #region Empty or Not

    [Fact]
    public void Test_ShouldBeEmpty_ShouldFail()
    {
        var sut = new List<int> { 3, 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeEmpty().Execute());
    }
    [Fact]
    public void Test_ShouldNotBeEmpty_ShouldFail()
    {
        var sut = new List<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldNotBeEmpty().Execute());
    }

    #endregion

    #region Contains or Not

    [Fact]
    public void Test_ShouldContain_ShouldFail()
    {
        var sut = new List<int> { 5 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void Test_ShouldNotContain_ShouldFail()
    {
        var sut = new List<int> { 3 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldNotContain(3).Execute());
    }

    [Fact]
    public void Test_ShouldContainMany_ShouldFail()
    {
        var sut = new List<int> { 3 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMany(3).Execute());
    }

    [Fact]
    public void Test_ShouldContainMany_Nullable_ShouldFail()
    {
        var sut = new List<string> { null };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMany(string.Empty).Execute());
    }

    [Fact]
    public void Test_ShouldContainSingle_ShouldFail()
    {
        var sut = new List<int> { 3, 3 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle(3).Execute());
    }

    [Fact]
    public void Test_ShouldContainSingle_Nullable_ShouldFail()
    {
        var sut = new List<string> { null };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle(string.Empty).Execute());
    }

    [Fact]
    public void Test_ShouldContainThisMany_ShouldFail()
    {
        var sut = new List<int> { 3, 3 };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainThisMany(3, 4).Execute());
    }

    [Fact]
    public void Test_ShouldContainThisMany_Nullable_ShouldFail()
    {
        var sut = new List<string> { null };
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainThisMany(string.Empty, 1).Execute());
    }

    #endregion

    #region DifferentCollections Count Generic

    [Fact]
    public void TestCount_Count_Array()
    {
        var sut = Array.Empty<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_Dictionary()
    {
        var sut = new Dictionary<int, string>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_HashSet()
    {
        var sut = new HashSet<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_Queue()
    {
        var sut = new Queue<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_Stack()
    {
        var sut = new Stack<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_LinkedList()
    {
        var sut = new LinkedList<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_SortedList()
    {
        var sut = new SortedList<int, string>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_SortedDictionary()
    {
        var sut = new SortedDictionary<int, string>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_ObservableCollection()
    {
        var sut = new ObservableCollection<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_SortedSet()
    {
        var sut = new SortedSet<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }
    #endregion

    #region DifferentCollections Count Concurrent

    [Fact]
    public void TestCount_BlockingCollection_Concurrent()
    {
        var sut = new BlockingCollection<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_ConcurrentBag_Concurrent()
    {
        var sut = new ConcurrentBag<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_ConcurrentDictionary_Concurrent()
    {
        var sut = new ConcurrentDictionary<int, bool>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_ConcurrentQueue_Concurrent()
    {
        var sut = new ConcurrentQueue<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_ConcurrentStack_Concurrent()
    {
        var sut = new ConcurrentStack<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    #endregion

    #region DifferentCollections Count NonGeneric

    [Fact]
    public void TestCount_HashTable_NonGeneric()
    {
        var sut = new Hashtable();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_ArrayList_NonGeneric()
    {
        var sut = new ArrayList();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_Queue_NonGeneric()
    {
        var sut = new Queue();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_Stack_NonGeneric()
    {
        var sut = new Stack();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_SortedList_NonGeneric()
    {
        var sut = new SortedList();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    [Fact]
    public void TestCount_BitArray_NonGeneric()
    {
        var sut = new BitArray(new[] { false });
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().CountShouldBeEqualTo(3).Execute());
    }

    #endregion

    #region DifferentCollections Contains Generic

    [Fact]
    public void TestContains_Count_Array()
    {
        var sut = Array.Empty<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_Dictionary()
    {
        var sut = new Dictionary<int, string>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute());
    }

    [Fact]
    public void TestContains_Dictionary_Passing()
    {
        var sut = new Dictionary<int, string>{{3, "hello"}};
        sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute();
    }

    [Fact]
    public void TestContains_HashSet()
    {
        var sut = new HashSet<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_Queue()
    {
        var sut = new Queue<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_Stack()
    {
        var sut = new Stack<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_LinkedList()
    {
        var sut = new LinkedList<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_SortedList()
    {
        var sut = new SortedList<int, string>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute());
    }

    [Fact]
    public void TestContains_SortedList_Passing()
    {
        var sut = new SortedList<int, string> { { 3, "hello" } };
        sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute();
    }

    [Fact]
    public void TestContains_SortedDictionary()
    {
        var sut = new SortedDictionary<int, string>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute());
    }

    [Fact]
    public void TestContains_SortedDictionary_Passing()
    {
        var sut = new SortedDictionary<int, string> { { 3, "hello" } };
        sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute();
    }

    [Fact]
    public void TestContains_ObservableCollection()
    {
        var sut = new ObservableCollection<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_SortedSet()
    {
        var sut = new SortedSet<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }
    #endregion

    #region DifferentCollections Contains Concurrent

    [Fact]
    public void TestContains_BlockingCollection_Concurrent()
    {
        var sut = new BlockingCollection<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_ConcurrentBag_Concurrent()
    {
        var sut = new ConcurrentBag<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_ConcurrentDictionary_Concurrent()
    {
        var sut = new ConcurrentDictionary<int, bool>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(new KeyValuePair<int, bool>(3, false)).Execute());
    }

    [Fact]
    public void TestContains_ConcurrentDictionary_Concurrent_Passing()
    {
        var sut = new ConcurrentDictionary<int, string> ();
        sut.TryAdd(3, "hello");

        sut.GetValidator().ShouldContain(new KeyValuePair<int, string>(3, "hello")).Execute();
    }

    [Fact]
    public void TestContains_ConcurrentQueue_Concurrent()
    {
        var sut = new ConcurrentQueue<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_ConcurrentStack_Concurrent()
    {
        var sut = new ConcurrentStack<int>();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    #endregion

    #region DifferentCollections Contains NonGeneric

    [Fact]
    public void TestContains_HashTable_NonGeneric()
    {
        var sut = new Hashtable();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_ArrayList_NonGeneric()
    {
        var sut = new ArrayList();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_Queue_NonGeneric()
    {
        var sut = new Queue();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_Stack_NonGeneric()
    {
        var sut = new Stack();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void TestContains_SortedList_NonGeneric()
    {
        var sut = new SortedList();
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3).Execute());
    }

    [Fact]
    public void BitArray_NonGeneric()
    {
        var sut = new BitArray(new[] { false });
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(true).Execute());
    }

    #endregion
}
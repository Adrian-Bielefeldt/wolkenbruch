using System.Collections;
using System.Collections.Generic;

public static class NavigatorData {

	public static float volume = 0.5f;

	public static Dictionary<int, bool> unlockedScenes = new Dictionary<int, bool>(){
		{1, true},
		{2, false},
		{3, false},
		{4, false}
	};

	public static Dictionary<int, string> chapterLocations = new Dictionary<int, string>(){
		{5, "finalScenes/Navigator"},
		{1, "finalScenes/Chapter01"},
		{2, "finalScenes/Chapter02"},
		{3, "finalScenes/Chapter03"},
		{4, "finalScenes/Chapter04"}
	};

	public static Dictionary<int, int> maxPointsGame = new Dictionary<int, int>() {
		{1, 4},
		{2, 4},
		{3, 2},
		{4, 4}
	};

	public static Dictionary<int, int> achievedPointsGame = new Dictionary<int, int>() {
		{1, 0},
		{2, 0},
		{3, 0},
		{4, 0}
	};

	public static Dictionary<int, int> maxPointsQuiz = new Dictionary<int, int>() {
		{1, 0},
		{2, 0},
		{3, 0},
		{4, 0}
	};

	public static Dictionary<int, int> achievedPointsQuiz = new Dictionary<int, int>() {
		{1, 0},
		{2, 0},
		{3, 0},
		{4, 0}
	};

	public static Dictionary<int, bool> chapterStarted = new Dictionary<int, bool>() {
		{1, false},
		{2, false},
		{3, false},
		{4, false}
	};
}

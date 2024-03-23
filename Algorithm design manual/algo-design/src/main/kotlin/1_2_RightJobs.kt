package a1_2

class `1_2_RightJobs` {
    fun compute(times: List<MovieProduction>) : Int {
        if (times.isEmpty()) {
            return 0
        }

        val sortedTimes = times.sortedBy { it.endTime }
        var result = 1;
        var currentEndTime = sortedTimes[0].endTime
        var index = 1;

        while (index < sortedTimes.count()) {
            if (sortedTimes[index].startTime >= currentEndTime) {
                result++
                currentEndTime = sortedTimes[index].endTime
            }

            index++
        }

        return result
    }
}

data class MovieProduction(
    val startTime: Int,
    val endTime: Int) {
}

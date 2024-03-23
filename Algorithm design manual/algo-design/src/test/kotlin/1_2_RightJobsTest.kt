package a1_2
import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class `1_2_RightJobsTest` {
    @Test
    fun check() {
        val response = `1_2_RightJobs`()
            .compute(listOf(
            MovieProduction(1, 3),
            MovieProduction(2, 4),
            MovieProduction(1, 10),
            MovieProduction(3, 5),
            MovieProduction(4, 7),
        ))

        assertEquals(2, response)
    }
}
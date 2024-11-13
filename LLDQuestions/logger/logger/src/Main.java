public class Main {
    public static void main(String[] args) {
        LogProcessor logger = new InfoProcessor(new DebugProcessor(new ErrorProcessor( null)));
        logger.log(1, "info msg");
        logger.log(2, "debug msg");
        logger.log(3, "error msg");
    }
}
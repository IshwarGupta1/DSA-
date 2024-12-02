@Entity
@Table(name = "employees")
public class Employee{
    @Id
    @GeneratedValue(strategy  = GenerationType.IDENTITY)
    private long Id;
    @Column(name = "name")
    private String name;

    @Column(nullable = false)
    private long Class;

    @ManyToOne
    @JoinColumn(name = "department")
    private String department;

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public long getClass() {
        return Class;
    }

    public void setClass(long aClass) {
        Class = aClass;
    }

    public String getDepartment() {
        return department;
    }

    public void setDepartment(String department) {
        this.department = department;
    }
}
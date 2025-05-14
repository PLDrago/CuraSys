CREATE USER IF NOT EXISTS 'patient'@'%' IDENTIFIED BY 'patient';
GRANT SELECT ON curasys.patients TO 'patient'@'%';
GRANT SELECT ON curasys.visits TO 'patient'@'%';
GRANT SELECT ON curasys.prescriptions TO 'patient'@'%';
GRANT SELECT ON curasys.medical_tests TO 'patient'@'%';
GRANT SELECT ON curasys.scheduled_tests TO 'patient'@'%';
GRANT SELECT ON curasys.test_results TO 'patient'@'%';
GRANT SELECT ON curasys.invoices TO 'patient'@'%';

CREATE USER IF NOT EXISTS 'medical_staff'@'%' IDENTIFIED BY 'medical';
GRANT SELECT, INSERT, UPDATE ON curasys.visits TO 'medical_staff'@'%';
GRANT SELECT, INSERT, UPDATE ON curasys.prescriptions TO 'medical_staff'@'%';
GRANT SELECT ON curasys.prescription_items TO 'medical_staff'@'%';
GRANT SELECT, INSERT, UPDATE ON curasys.test_results TO 'medical_staff'@'%';
GRANT SELECT, INSERT, UPDATE ON curasys.scheduled_tests TO 'medical_staff'@'%';
GRANT SELECT, INSERT, UPDATE ON curasys.patients TO 'medical_staff'@'%';
GRANT SELECT ON curasys.medicines TO 'medical_staff'@'%';
GRANT SELECT ON curasys.medical_tests TO 'medical_staff'@'%';

CREATE USER IF NOT EXISTS 'admin_staff'@'%' IDENTIFIED BY 'administration';
GRANT SELECT, INSERT, UPDATE ON curasys.patients TO 'admin_staff'@'%';
GRANT SELECT, INSERT, UPDATE ON curasys.invoices TO 'admin_staff'@'%';
GRANT SELECT, INSERT, UPDATE ON curasys.visits TO 'admin_staff'@'%';
GRANT SELECT ON curasys.system_users TO 'admin_staff'@'%';

CREATE USER IF NOT EXISTS 'admin'@'%' IDENTIFIED BY 'zaq1@WSX';
GRANT ALL PRIVILEGES ON curasys.* TO 'admin'@'%';

FLUSH PRIVILEGES;

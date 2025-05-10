export interface Todo {
    id: string;
    title: string;
    description?: string;
    status: 'Pending' | 'InProgress' | 'Completed';
    priority: 'Low' | 'Medium' | 'High';
    dueDate?: Date;
    createdDate: Date;
    lastModifiedDate: Date;
}

